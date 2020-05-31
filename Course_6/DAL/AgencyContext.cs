using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    /// <summary>
    /// A DbContext instance represents a combination of the Unit Of Work and Repository
    /// patterns such that it can be used to query from a database and group together
    /// changes that will then be written back to the store as a unit.DbContext is conceptually
    /// </summary>
    internal class AgencyContext : DbContext
    {
        /// <summary>
        /// Creates instance of AgencyContext
        /// </summary>
        public AgencyContext() : base("name=AgencyDatabase")
        {
        }

        /// <summary>
        /// A DbSet represents the collection of all Roles in the context, or that can
        /// be queried from the database, of a given type. DbSet objects are created from
        /// a DbContext using the DbContext.Set method.
        /// </summary>
        public IDbSet<Role> Roles { get; set; }

        /// <summary>
        /// A DbSet represents the collection of all Users in the context, or that can
        /// be queried from the database, of a given type. DbSet objects are created from
        /// a DbContext using the DbContext.Set method.
        /// </summary>
        public IDbSet<User> Users { get; set; }

        /// <summary>
        /// A DbSet represents the collection of all Services in the context, or that can
        /// be queried from the database, of a given type. DbSet objects are created from
        /// a DbContext using the DbContext.Set method.
        /// </summary>
        public IDbSet<Service> Services { get; set; }
    }
}
