using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.TextTemplating;
using Fwk.Bases.ViewModels;
using System.Collections;
using System.Reflection;
namespace Fwk.T4Gen
{

    public class EntityModelToObservable
    {
        public static Project GetProject(ITextTemplatingEngineHost host)
        {
            IServiceProvider hostServiceProvider = (IServiceProvider)host;
            if (hostServiceProvider == null)
                throw new Exception("Host property returned unexpected value (null).");

            DTE dte = (DTE)hostServiceProvider.GetService(typeof(DTE));
            if (dte == null)
                throw new Exception("Unable to retrieve EnvDTE.DTE");

            Array activeSolutionProjects = (Array)dte.ActiveSolutionProjects;
            if (activeSolutionProjects == null)
                throw new Exception("DTE.ActiveSolutionProjects returned null.");

            Project dteProject = (Project)activeSolutionProjects.GetValue(0);
            if (dteProject == null)
                throw new Exception("DTE.ActiveSolutionProjects returned null.");

            return dteProject;
        }

        public static List<Type> GetDefinedTypesOnAllAssemblies(ITextTemplatingEngineHost host)
        {

            string targetDir = host.ResolveAssemblyReference("$(TargetDir)");
            //Directory.SetCurrentDirectory(targetDir);

            DirectoryInfo d = new DirectoryInfo(targetDir);

            FileInfo[] files = d.GetFiles("*.exe|*.dll");

            var list = new List<Type>();

            foreach (FileInfo dll in files)
            {
              Assembly ass =  System.Reflection.Assembly.LoadFile(dll.FullName);
              foreach (Type type in ass.GetTypes())
              {
                  if (type.IsAbstract) continue;
                  if (type.Name != typeof(BaseViewModel).Name) continue;
                  list.Add(type);
              }
                
            }
            return list;
        }



        public static List<Type> Types()
        {
            var list = new List<Type>();

         
            foreach (Type type in System.Reflection.Assembly.GetAssembly(typeof(BaseViewModel)).GetTypes())
            {
                if (type.IsAbstract) continue;
                if (type.Name != typeof(BaseViewModel).Name) continue;
                list.Add(type);
            }



            return list;
        }

        public static List<EnvDTE.CodeClass> GetDefinedTypes(ITextTemplatingEngineHost host)
        {
            var listClass = new List<EnvDTE.CodeClass>();
            Project project = GetProject(host);
            foreach (EnvDTE.CodeElement element in project.CodeModel.CodeElements)
            {
                if (element.Kind == EnvDTE.vsCMElement.vsCMElementClass)
                {
                    var type = (EnvDTE.CodeClass)element;
                    // do stuff with that class here

                    //var allProperties = VisualStudioHelper.GetAllCodeElementsOfType(type.Members, EnvDTE.vsCMElement.vsCMElementProperty, true);
                        foreach(EnvDTE.CodeProperty property in type.Members)
                        {
                            if (property.Kind == EnvDTE.vsCMElement.vsCMElementProperty)
                            {
                                //list.Add(property); 
                            }
                           
                            
                        }
                        listClass.Add(type);
                }
            }
            return listClass;
        }

        //public static List<Type> RetriveAllModels()
        //{
        //    var list = new List<Type>();
        //    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        //    {
        //        Type[] types = assembly.GetTypes();
        //        foreach (Type type in types)
        //        {
        //            if (type.BaseType == typeof(BaseViewModel))
        //            {
        //                list.Add(type);
        //            }
        //        }

        //    }
        //    return list;
        //}
        
    }

    public class EnvDteHelper
    {
        public static Project GetProject(ITextTemplatingEngineHost host)
        {
            IServiceProvider hostServiceProvider = (IServiceProvider)host;
            if (hostServiceProvider == null)
                throw new Exception("Host property returned unexpected value (null).");

            DTE dte = (DTE)hostServiceProvider.GetService(typeof(DTE));
            if (dte == null)
                throw new Exception("Unable to retrieve EnvDTE.DTE");

            Array activeSolutionProjects = (Array)dte.ActiveSolutionProjects;
            if (activeSolutionProjects == null)
                throw new Exception("DTE.ActiveSolutionProjects returned null.");

            Project dteProject = (Project)activeSolutionProjects.GetValue(0);
            if (dteProject == null)
                throw new Exception("DTE.ActiveSolutionProjects returned null.");

            return dteProject;
        }

        public static List<ProjectItem> GetJsProjectItems(Project project)
        {
            List<ProjectItem> jsProjectItems = new List<ProjectItem>();

            foreach (ProjectItem projectItem in project.ProjectItems)
            {
                GetJsProjectItems(projectItem, jsProjectItems);

                if (projectItem.Name.EndsWith(".js") && !projectItem.Name.EndsWith(".min.js"))
                    jsProjectItems.Add(projectItem);
            }

            return jsProjectItems;
        }

        public static void SaveMinifiedCode(ProjectItem originalJsItem, string minifiedCode)
        {
            string outputFileName = Path.ChangeExtension(originalJsItem.FileNames[0], ".min.js");
            File.WriteAllText(outputFileName, minifiedCode);

            ProjectItem parentProjectItem = originalJsItem.Properties.Parent;
            parentProjectItem.ProjectItems.AddFromFile(outputFileName);
        }

        private static void GetJsProjectItems(ProjectItem parentProjectItem, List<ProjectItem> jsProjectItems)
        {
            foreach (ProjectItem projectItem in parentProjectItem.ProjectItems)
            {
                GetJsProjectItems(projectItem, jsProjectItems);

                if (projectItem.Name.EndsWith(".js") && !projectItem.Name.EndsWith(".min.js"))
                    jsProjectItems.Add(projectItem);
            }
        }

    }

}
