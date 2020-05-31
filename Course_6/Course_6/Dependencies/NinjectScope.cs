using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace Course_6.Dependencies
{
    /// <summary>
    /// Implementation of interface for the range of the dependencies.
    /// </summary>
    public class NinjectScope : IDependencyScope
    {
        /// <summary>
        /// Provides a path to resolve instances
        /// </summary>
        protected IResolutionRoot ResolutionRoot;

        /// <summary>
        /// Create instance of <see cref="NinjectScope"/>
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectScope(IResolutionRoot kernel)
        {
            ResolutionRoot = kernel;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <returns>The retrieved service.</returns>
        /// <param name="serviceType">The service to be retrieved.</param>
        public object GetService(Type serviceType)
        {
            IRequest request = ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return ResolutionRoot.Resolve(request).SingleOrDefault();
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <returns>The retrieved collection of services.</returns>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = ResolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return ResolutionRoot.Resolve(request).ToList();
        }

        /// <summary>
        /// Performs application-defined tasks associated
        /// with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            IDisposable disposable = (IDisposable)ResolutionRoot;
            disposable?.Dispose();
            ResolutionRoot = null;
        }
    }
}