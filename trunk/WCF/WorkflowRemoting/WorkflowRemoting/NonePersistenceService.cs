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
using System.IO;
using System.IO.Compression;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime.Hosting;
using System.Collections.Specialized;
using System.Workflow.Runtime;
using System.Threading;
#endregion

namespace RKiss.WorkflowRemoting
{
    /// <summary>
    /// Null persistence service for the statefull transactional workflows. This service does nothing, it can be used for monitoring purposes
    /// </summary>
	public class NonePersistenceService : WorkflowPersistenceService
    {
        #region Private Members
        private bool unloadOnIdle = false;
        #endregion

        #region Constructors
        public NonePersistenceService()
        {
        }
        public NonePersistenceService(NameValueCollection parameters)
        {
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    if (key == "UnloadOnIdle")
                    {
                        unloadOnIdle = bool.Parse(parameters[key]);
                    }
                }
            }
        }
        #endregion

        #region WorkflowPersistenceService overrides
        /// <summary>
        /// Save workflow instance state at point of persistence
        /// </summary>
        /// <param name="rootActivity">Workflow Root Instance</param>
        /// <param name="unlock">option of locking instance state if it is shared across multiple runtimes or multiple phase instance update</param>
        protected override void SaveWorkflowInstanceState(Activity rootActivity, bool unlock)
        {
            // Save the workflow (for logging purpose)
            Guid contextGuid = (Guid)rootActivity.GetValue(Activity.ActivityContextGuidProperty);   
        }

        /// <summary>
        /// Load workflow instance state
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        protected override Activity LoadWorkflowInstanceState(Guid instanceId)
        {
            throw new NotSupportedException("NullPersistenceService.LoadWorkflowInstanceState");
        }

        /// <summary>
        /// Unlock workflow instance state.  
        /// </summary>
        /// <param name="state"></param>
        /// <remarks>instance state locking is necessary when multiple runtimes share instance persistence store</remarks>
        protected override void UnlockWorkflowInstanceState(Activity state)
        {
            Guid contextGuid = (Guid)state.GetValue(Activity.ActivityContextGuidProperty);
        }

        /// <summary>
        /// Save completed activity state
        /// </summary>
        /// <param name="rootActivity"></param>
        protected override void SaveCompletedContextActivity(Activity rootActivity)
        {
            Guid contextGuid = (Guid)rootActivity.GetValue(Activity.ActivityContextGuidProperty);
        }

        /// <summary>
        /// Load completed activity state.
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="outerActivity"></param>
        /// <returns></returns>
        protected override Activity LoadCompletedContextActivity(Guid activityId, Activity outerActivity)
        {
            throw new NotSupportedException("NullPersistenceService.LoadCompletedContextActivity");
        }

        /// <summary>
        /// Check the option
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        protected override bool UnloadOnIdle(Activity activity)
        {
            return unloadOnIdle;
        }
        #endregion
    }
}
