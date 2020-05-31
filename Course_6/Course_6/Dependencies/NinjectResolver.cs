using System.Web.Http.Dependencies;
using Ninject;

namespace Course_6.Dependencies
{
    /// <summary>
    /// Represents a dependency injection container
    /// </summary>
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        /// <summary>
        /// A super-factory that can create objects of all kinds
        /// </summary>
        private readonly IKernel _kernel;

        /// <summary>
        /// Create instance of <see cref="NinjectResolver"/>
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Starts a resolution scope. 
        /// </summary>
        /// <returns>Range of the dependencies</returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}