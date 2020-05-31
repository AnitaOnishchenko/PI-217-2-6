using DAL.Models;
using System;

namespace DAL.Repository
{
    /// <summary>
    /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
    /// </summary>
    internal class UnitOfWork : IDisposable, IUnitOfWork
    {
        /// <summary>
        /// A DbContext instance represents a combination of the Unit Of Work and Repository
        /// patterns such that it can be used to query from a database and group together
        /// changes that will then be written back to the store as a unit.DbContext is conceptually
        /// </summary>
        private readonly AgencyContext _agencyContext;

        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain Role objects
        /// </summary>
        public IGenericRepository<Role> Roles { get; set; }

        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain User objects
        /// </summary>
        public IGenericRepository<User> Users { get; set; }

        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain Service objects
        /// </summary>
        public IGenericRepository<Service> Services { get; set; }

        /// <summary>
        /// Flag to define that data is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Creates instance of <see cref="UnitOfWork"/>
        /// </summary>
        /// <param name="agencyContext">DbContext instance</param>
        /// <param name="roles">Roles repository</param>
        /// <param name="users">Users repository</param>
        /// <param name="services">Services repository</param>
        public UnitOfWork(AgencyContext agencyContext, IGenericRepository<Role> roles, IGenericRepository<User> users, IGenericRepository<Service> services)
        {
            _agencyContext = agencyContext;
            Roles = roles;
            Users = users;
            Services = services;
        }

        /// <summary>
        /// Release unmanaged resources used application
        /// </summary>
        /// <param name="disposing">If true - dispose , else do nothing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                _agencyContext.Dispose();
            }

            _isDisposed = true;
        }

        /// <summary>
        /// Release unmanaged resources used application
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves data to Database
        /// </summary>
        public void Save()
        {
            _agencyContext.SaveChanges();
        }
    }
}
