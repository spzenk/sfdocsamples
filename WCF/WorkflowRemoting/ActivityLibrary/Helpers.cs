//*****************************************************************************
//    Description.....Custom Remoting for Workflow
//                                
//    Author..........Roman Kiss, rkiss@pathcom.com
//    Copyright © 2006 ATZ Consulting Inc. (see included license.rtf file)        
//                        
//    Date Created:    07/07/06
//
//    Date        Modified By     Description
//-----------------------------------------------------------------------------
//    07/07/06    Roman Kiss     Initial Revision
//*****************************************************************************
//
#region References
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
#endregion

namespace RKiss.ActivityLibrary 
{
    #region Helpers
    public sealed class Helpers
    {
        private Helpers() { }

        public static string ConvertListToText(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string text in list)
            {
                sb.Append(text);
                sb.Append(", ");
            }
            return sb.ToString().TrimEnd(new char[] { ' ', ',' });
        }

        public static void GetAllEnabledActivities(CompositeActivity activity, List<Activity> list)
        {          
            if (activity != null && list != null)
            {
                foreach (Activity item in activity.EnabledActivities)
                {
                    if (item is SequenceActivity)
                        GetAllEnabledActivities(item as SequenceActivity, list);
                    else if(item is CompositeActivity)
                        GetAllEnabledActivities(item as CompositeActivity, list);
                    else
                        list.Add(item);
                }
            }
        }
      
        public static Activity GetRootActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            while (activity.Parent != null)
            {
                activity = activity.Parent;
            }
            return activity;
        }

        public static Activity GetTopActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            while (activity.Parent != null)
            {
                if (activity.Parent == null)
                    break;
                activity = activity.Parent;
            }
            return activity;
        }

        public static bool IsLoopActivity(Activity activity)
        {
            return (activity is WhileActivity || activity is ReplicatorActivity || activity is ConditionedActivityGroup);
        }

        public static object[] GetParameters(MethodBase methodBase, WorkflowParameterBindingCollection parameterBindings)
        {
            ParameterInfo[] infoArray = methodBase.GetParameters();
            object[] objArray = new object[infoArray.Length];
            int ii = 0;
            foreach (ParameterInfo pi in infoArray)
            {
                if (parameterBindings.Contains(pi.Name))
                {
                    WorkflowParameterBinding binding = parameterBindings[pi.Name];
                    objArray[ii] = binding.Value;
                }
                ii++;
            }
            return objArray;
        }

        public static void SaveOutRefParameters(object[] actualParameters, MethodBase methodBase, WorkflowParameterBindingCollection parameterBindings)
        {
            int ii = 0;
            BinaryFormatter bf = null;
            foreach (ParameterInfo pi in methodBase.GetParameters())
            {
                if (parameterBindings.Contains(pi.Name) && (pi.ParameterType.IsByRef || (pi.IsIn && pi.IsOut)))
                {
                    WorkflowParameterBinding binding = parameterBindings[pi.Name];
                    if (bf == null)
                    {
                        bf = new BinaryFormatter();
                    }
                    binding.Value = CloneOutboundValue(actualParameters[ii], bf, pi.Name);
                }
                ii++;
            }
        }
        public static object CloneOutboundValue(object source, BinaryFormatter formatter, string name)
        {
            if ((source == null) || source.GetType().IsValueType)
            {
                return source;
            }
            ICloneable cloneable1 = source as ICloneable;
            if (cloneable1 != null)
            {
                return cloneable1.Clone();
            }
            MemoryStream ms = new MemoryStream(0x400);
            try
            {
                formatter.Serialize(ms, source);
            }
            catch
            {
                throw new InvalidOperationException("Error_CallExternalMethodArgsSerializationException");
            }
            ms.Position = 0;
            return formatter.Deserialize(ms);
        }

        public static void ValidateRoles(Activity activity, string identity)
        {
            DependencyProperty dp = DependencyProperty.FromName("Roles", activity.GetType().BaseType);
            if (dp == null)
            {
                dp = DependencyProperty.FromName("Roles", activity.GetType());
            }
            if (dp != null)
            {
                ActivityBind bind = activity.GetBinding(dp);
                if (bind != null)
                {
                    WorkflowRoleCollection collection = bind.GetRuntimeValue(activity) as WorkflowRoleCollection;
                    if ((collection != null) && !collection.IncludesIdentity(identity))
                    {
                        throw new WorkflowAuthorizationException(activity.Name, identity);
                    }
                }
            }
        }

        public static void ValidateRoles(Activity activity, IMethodMessage message)
        {
            if (activity != null && message != null && message.LogicalCallContext != null)
            {
                object data = message.LogicalCallContext.GetData("__identitycontext__");
                if (data != null)
                {
                    string identity = data.GetType().InvokeMember("Identity", BindingFlags.NonPublic | BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, data, new object[0], CultureInfo.InvariantCulture) as string;
                    Helpers.ValidateRoles(activity, identity);
                }
            }
        }
    }
    #endregion     

    #region ParameterBindingPropertyDescriptor
    public class ParameterBindingPropertyDescriptor<T> : PropertyDescriptor where T : class
    {
        Type _type = null;

        public ParameterBindingPropertyDescriptor(string propertyName, Type parameterType, Attribute[] attrs)
            : base(propertyName, attrs)
        {
            this._type = parameterType;
        }

        public override TypeConverter Converter
        {
            get
            {
                return new ActivityBindTypeConverter();
            }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get
            {
                return typeof(T);
            }
        }
        public override object GetValue(object component)
        {
            WorkflowParameterBindingCollection parameters = GetParameters(component);
            if (parameters != null && parameters.Contains(this.Name))
            {
                if (parameters[this.Name].IsBindingSet(WorkflowParameterBinding.ValueProperty))
                    return parameters[this.Name].GetBinding(WorkflowParameterBinding.ValueProperty);
                else
                    return parameters[this.Name].GetValue(WorkflowParameterBinding.ValueProperty);
            }
            return null;
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override Type PropertyType
        {
            get
            {
                if (_type != null)
                    return _type;
                else
                    return typeof(ActivityBind);
            }
        }
        public override void ResetValue(object component)
        {

        }
        public override void SetValue(object component, object value)
        {
            if (component != null)
            {
                ISite site = GetSite(component);
                IComponentChangeService changeService = null;
                if (site != null)
                    changeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));

                // Raise the OnComponentChanging event
                changeService.OnComponentChanging(component, this);

                // Save the old value
                object oldValue = GetValue(component);

                try
                {
                    WorkflowParameterBindingCollection parameters = GetParameters(component);
                    if (parameters != null)
                    {
                        if (value == null)
                            // Remove the binding from the ParameterBindings collection
                            parameters.Remove(this.Name);
                        else
                        {
                            // Add the binding to the ParameterBindings collection
                            WorkflowParameterBinding binding = null;
                            if (parameters.Contains(this.Name))
                                binding = parameters[this.Name];
                            else
                            {
                                binding = new WorkflowParameterBinding(this.Name);
                                parameters.Add(binding);
                            }

                            // Set the binding value on the ParameterBindings collection correspondent binding item
                            if (value is ActivityBind)
                                binding.SetBinding(WorkflowParameterBinding.ValueProperty, value as ActivityBind);
                            else
                                binding.SetValue(WorkflowParameterBinding.ValueProperty, value);
                        }
                    }
                    // Raise the OnValueChanged event
                    OnValueChanged(component, EventArgs.Empty);
                }
                catch (Exception)
                {
                    value = oldValue;
                    throw;
                }
                finally
                {
                    if (changeService != null)
                    {
                        // Raise the OnComponentChanged event
                        changeService.OnComponentChanged(component, this, oldValue, value);
                    }
                }
            }
        }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        private WorkflowParameterBindingCollection GetParameters(object component)
        {
            WorkflowParameterBindingCollection collection = null;
            if (component.GetType().GetProperty("Parameters", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, typeof(WorkflowParameterBindingCollection), new Type[0], new ParameterModifier[0]) != null)
            {
                collection = component.GetType().InvokeMember("Parameters", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, component, new object[0], CultureInfo.InvariantCulture) as WorkflowParameterBindingCollection;
            }
            return collection;
        }
    }
    #endregion

    #region MethodPropertyValueProviderTypeConverter
    public class MethodPropertyValueProviderTypeConverter : TypeConverter
    {
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            StringCollection names = new StringCollection();
            object instance = null;

            object[] instances = context.Instance as object[];
            if (instances != null && instances.Length > 0)
                instance = instances[0];
            else
                instance = context.Instance;

            Type type = instance.GetType().InvokeMember("Type", BindingFlags.ExactBinding | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance, null, instance, new object[0], CultureInfo.InvariantCulture) as Type;
            if (type != null)
            {
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo mi in methods)
                {
                    names.Add(mi.Name);
                }
            }
            return new TypeConverter.StandardValuesCollection(names);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
    #endregion

  

}

 //public static void GetAllEnabledActivities(CompositeActivity activity, List<Activity> list)
 //       {          
 //           if (activity != null && list != null)
 //           {
 //               foreach (Activity item in activity.EnabledActivities)
 //               {
 //                   if (item is SequenceActivity)
 //                       GetAllEnabledActivities(item as SequenceActivity, list);
 //                   else if(item is CompositeActivity)
 //                       GetAllEnabledActivities(item as CompositeActivity, list);
 //                   //else if (item is ConditionedActivityGroup)
 //                   //    GetAllEnabledActivities(item as CompositeActivity, list);
 //                   //else if (item is StateMachineWorkflowActivity)
 //                   //    GetAllEnabledActivities(item as CompositeActivity, list);
 //                   //else if (item is StateActivity)
 //                   //    GetAllEnabledActivities(item as CompositeActivity, list);
 //                   //else if (item is StateInitializationActivity)
 //                   //    GetAllEnabledActivities(item as CompositeActivity, list);
 //                   //else if (item is StateFinalizationActivity)
 //                   //    GetAllEnabledActivities(item as CompositeActivity, list);
 //                   else
 //                       list.Add(item);
 //               }
 //           }
 //       }
