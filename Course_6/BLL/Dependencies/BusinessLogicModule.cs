using BLL.Logic;
using DAL.Dependencies;
using DAL.Repository;
using Ninject;
using Ninject.Modules;

namespace BLL.Dependencies
{
    /// <summary>
    /// A loadable unit that defines bindings of business logic layer
    /// </summary>
    public class BusinessLogicModule : NinjectModule
    {
        /// <summary>
        ///  Loads the module into the kernel
        /// </summary>
        public override void Load()
        {
            var unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
            Bind<IServiceService>().ToConstructor(x => new ServiceService(unitOfWork));
            Bind<IUserService>().ToConstructor(x => new UserService(unitOfWork));
        }
    }
}
