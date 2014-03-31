using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace NinjectSample.Clases
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        public IKernel Container
        {
            get { return _container; }
        }

        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            // noop
            //IDisposable disposable = resolver as IDisposable;
            //if (disposable != null)
            //    disposable.Dispose();

            //resolver = null;
        }

    }
    //public class NinjectDependencyResolver_otro : NinjectDependencyScope, IDependencyResolver
    //{
    //    private IKernel kernel;

    //    public NinjectDependencyResolver_otro(IKernel kernel)
    //        : base(kernel)
    //    {
    //        this.kernel = kernel;
    //    }

    //    public IDependencyScope BeginScope()
    //    {
    //        return new NinjectDependencyScope(kernel.BeginBlock());
    //    }

    //}
}
