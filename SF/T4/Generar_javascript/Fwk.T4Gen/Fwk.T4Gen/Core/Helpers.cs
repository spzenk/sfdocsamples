using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.TextTemplating;
using Fwk.Bases.ViewModels;
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

        public static List<Type> Properties()
        {
            var list = new List<Type>();


            foreach (Type type in System.Reflection.Assembly.GetAssembly(typeof(BaseViewModel)).GetTypes())
            {
                if (type.IsAbstract) continue;	// only generate JS viewmodels for non-abstract classes

                list.Add(type);
            }
            return list;
        }
        
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
