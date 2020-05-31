using DAL.Models;
using DAL.Repository;
using Ninject.Modules;

namespace DAL.Dependencies
{
    /// <summary>
    /// A loadable unit that defines bindings of data access layer
    /// </summary>
    public class DataAccessModule : NinjectModule
    {
        /// <summary>
        ///  Loads the module into the kernel
        /// </summary>
        public override void Load()
        {
            var agencyContext = new AgencyContext();

            Bind<IGenericRepository<User>>().ToConstructor(x => new AgencyRepository<User>(agencyContext));
            Bind<IGenericRepository<Role>>().ToConstructor(x => new AgencyRepository<Role>(agencyContext));
            Bind<IGenericRepository<Service>>().ToConstructor(x => new AgencyRepository<Service>(agencyContext));

            Bind<IUnitOfWork>().ToConstructor
                (x => new UnitOfWork(agencyContext, x.Inject<IGenericRepository<Role>>(), x.Inject<IGenericRepository<User>>(), x.Inject<IGenericRepository<Service>>()));
        }
    }
}
