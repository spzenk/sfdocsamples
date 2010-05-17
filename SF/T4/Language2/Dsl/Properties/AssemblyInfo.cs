#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"pelsoft")]
[assembly: AssemblyProduct(@"FWK_Dsl")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"pelsoft.FWK_Dsl.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100B9E3B288AA81DBB9AF2EB614BFD70EDA488B74D6B8CFA60D095F4FAB48A5E3921A7F60889D87CBEC6B7A5BE603BA009FD87E9E001752850C5D8E10B0D796404DEB19A2BA84619720825063BE492F1EC71725057891984063122F628723EC51C99E1C7D19B3C041544FDB2CA3FBE6CBEBA7615957F834DE4734C35B27CDE2CDBE")]