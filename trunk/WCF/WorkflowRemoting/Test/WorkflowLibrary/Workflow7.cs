using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//
using RKiss.WorkflowRemoting;

namespace WorkflowLibrary
{
    [CreateWorkflowByXOML(WorkflowDefinitionKey = "@workflow7")]
    public class Workflow7 : IXomlLoader
    {
        #region IXomlLoader Members
        public Stream GetWorkflowDefinition(string key, Dictionary<string, object> namedArgumentValues)
        {
            return File.OpenRead(key);
        }
        public Stream GetWorkflowRules(string key, Dictionary<string, object> namedArgumentValues)
        {
            return null;
        }
        #endregion
    }
}
