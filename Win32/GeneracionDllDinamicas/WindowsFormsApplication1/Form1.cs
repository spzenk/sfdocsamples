using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Reflection;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        void metodo()
        {
            // Create a weak assembly name
            AssemblyName an = new AssemblyName();

            // Version is 1.0.0.0
            an.Version = new Version(1, 0, 0, 0);
            // Set the assembly name
            an.Name = "QuoteOfTheDay";

            // Define a dynamic assembly
            AssemblyBuilder ab = System.AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Save);

            // Define a dynamic module (same name as the dynamic assembly; we have a single module assembly)
            ModuleBuilder modBuilder = ab.DefineDynamicModule("QuoteOfTheDay", "QuoteOfTheDay.dll");

            // Create the public QuoteOfTheDay type (namespace is QuoteOfTheDay)
            TypeBuilder tb = modBuilder.DefineType("QuoteOfTheDay.QuoteOfTheDay", TypeAttributes.Class | TypeAttributes.Public);
            // Define two fields (both private)
            FieldBuilder m_Quotes = tb.DefineField("m_Quotes", typeof(System.Collections.ArrayList), FieldAttributes.Private);
            FieldBuilder m_Random = tb.DefineField("m_Random", typeof(System.Random), FieldAttributes.Private);
            //Create a new constructor (public with one string argument)
            ConstructorBuilder cb = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,
                                           new Type[] { typeof(String) });

            // Get the constructor's IL generator
            ILGenerator ilgen = cb.GetILGenerator();
            // Declare the "tr" local
            ilgen.DeclareLocal(typeof(System.IO.TextReader));
            // Declare the "quote" local
            ilgen.DeclareLocal(typeof(System.String));

            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Call the base constructor (no args)
            ilgen.Emit(OpCodes.Call, typeof(Object).GetConstructor(new Type[0]));

            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Create new ArrayList obj
            ilgen.Emit(OpCodes.Newobj, typeof(System.Collections.ArrayList).GetConstructor(new Type[0]));
            // Store in field "m_Quotes"
            ilgen.Emit(OpCodes.Stfld, m_Quotes);

            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Create new Random obj
            ilgen.Emit(OpCodes.Newobj, typeof(System.Random).GetConstructor(new Type[0]));
            // Store in field "m_Random"
            ilgen.Emit(OpCodes.Stfld, m_Random);

            // Load constructor argument "filename"
            ilgen.Emit(OpCodes.Ldarg_1);
            // Call File.OpenText(string)
            ilgen.Emit(OpCodes.Call, typeof(System.IO.File).GetMethod("OpenText"));
            // Store the result in the "tr" local
            ilgen.Emit(OpCodes.Stloc_0);

            // Define the loop and exit labels (for our "while" construct)
            System.Reflection.Emit.Label loop = ilgen.DefineLabel();
            System.Reflection.Emit.Label exit = ilgen.DefineLabel();

            // Mark the loop label
            ilgen.MarkLabel(loop);

            // Load local "tr"
            ilgen.Emit(OpCodes.Ldloc_0);
            // Call tr.ReadLine() (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.IO.TextReader).GetMethod("ReadLine"));
            // Store the result in the local "quote"
            ilgen.Emit(OpCodes.Stloc_1);
            // Load the local "quote"
            ilgen.Emit(OpCodes.Ldloc_1);
            // Branch to the exit label if "quote" is null
            ilgen.Emit(OpCodes.Brfalse_S, exit);

            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Load "m_Quotes" field
            ilgen.Emit(OpCodes.Ldfld, m_Quotes);
            // Load local "quote"
            ilgen.Emit(OpCodes.Ldloc_1);
            // Call m_Quotes.Add(object) (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.Collections.ArrayList).GetMethod("Add"));
            // Pop the result of m_Quotes.Add(object) (unused)
            ilgen.Emit(OpCodes.Pop);
            // Unconditional branch to the loop label
            ilgen.Emit(OpCodes.Br_S, loop);

            // Mark the exit label
            ilgen.MarkLabel(exit);
            // Load local "tr"
            ilgen.Emit(OpCodes.Ldloc_0);
            // Call tr.Close() (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.IO.TextReader).GetMethod("Close"));

            // Emit return opcode
            ilgen.Emit(OpCodes.Ret);


            // Define the GetRandomQuote method
            MethodBuilder mb = tb.DefineMethod("GetRandomQuote", MethodAttributes.Public, CallingConventions.Standard,
                                    typeof(System.String), new Type[0]);

            // Get the IL generator for the method
            ilgen = mb.GetILGenerator();
            // Declare the "count" local
            ilgen.DeclareLocal(typeof(int));

            // Define the cont label
            System.Reflection.Emit.Label cont = ilgen.DefineLabel();

            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Load field "m_Quotes"
            ilgen.Emit(OpCodes.Ldfld, m_Quotes);
            // Call m_Quotes.get_Count() (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.Collections.ArrayList).GetMethod("get_Count"));
            // Store in local "count"
            ilgen.Emit(OpCodes.Stloc_0);

            // Load local "count"
            ilgen.Emit(OpCodes.Ldloc_0);
            // Branch if count is not 0
            ilgen.Emit(OpCodes.Brtrue_S, cont);

            // Load the string ""
            ilgen.Emit(OpCodes.Ldstr, "");
            // Return
            ilgen.Emit(OpCodes.Ret);

            // Mark the cont label
            ilgen.MarkLabel(cont);
            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Load field "m_Quotes"
            ilgen.Emit(OpCodes.Ldfld, m_Quotes);
            // Load "this"
            ilgen.Emit(OpCodes.Ldarg_0);
            // Load field "m_Random"
            ilgen.Emit(OpCodes.Ldfld, m_Random);
            // Load local "count"
            ilgen.Emit(OpCodes.Ldloc_0);
            // Call m_Random.Next(int) (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.Random).GetMethod("Next", new Type[] { typeof(int) }));
            // Call m_Quotes.get_Item(int) (virtual)
            ilgen.Emit(OpCodes.Callvirt, typeof(System.Collections.ArrayList).GetMethod("get_Item"));
            // Cast the result to string
            ilgen.Emit(OpCodes.Castclass, typeof(System.String));
            // Return
            ilgen.Emit(OpCodes.Ret);
            // "Bake" the QuoteOfTheDay type
            tb.CreateType();
            // Save the assembly to the file specified
            ab.Save("QuoteOfTheDay.dll");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            metodo();
        }
    }
}
