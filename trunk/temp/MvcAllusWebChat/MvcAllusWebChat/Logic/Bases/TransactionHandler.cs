using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fwk.Transaction;

namespace WebChat.Common
{
    /// <summary>
    /// Atributo para decorar Acciones de controllers que requieren manejo de contexto transaccional
    /// <example>
    /// [TransactionHandlerAttribute(Behaviour= TransactionalBehaviour.RequiresNew,
    ///                              IsolationLevel= IsolationLevel.ReadUncommitted)]
    /// public ActionResult Create(Person person)
    /// {
    ///     // Do create
    /// }
    /// </example>
    /// </summary>
    public class TransactionHandlerAttribute : ActionFilterAttribute
    {
        public TransactionalBehaviour Behaviour { get; set; }
        public IsolationLevel IsolationLevel { get; set; }
        private TransactionScopeHandler transactionScopeHandler;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null)
            {
                if (Behaviour == null)
                    Behaviour = TransactionalBehaviour.RequiresNew;

                if (IsolationLevel == null)
                    IsolationLevel = IsolationLevel.ReadCommitted;
                transactionScopeHandler = new TransactionScopeHandler(Behaviour, IsolationLevel, new TimeSpan(0, 0, 0));
                transactionScopeHandler.InitScope();
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null && transactionScopeHandler != null)
                transactionScopeHandler.Complete();
            else
                transactionScopeHandler.Abort();

            base.OnActionExecuted(filterContext);
        }
    }
}