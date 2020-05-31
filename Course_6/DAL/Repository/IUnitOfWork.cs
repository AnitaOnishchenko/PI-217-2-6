using DAL.Models;

namespace DAL.Repository
{
    /// <summary>
    /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain Role objects
        /// </summary>
        IGenericRepository<Role> Roles { get; set; }

        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain User objects
        /// </summary>
        IGenericRepository<User> Users { get; set; }

        /// <summary>
        /// The Repository mediates between the domain and data mapping layers, acting like an in-memory collection of domain Service objects
        /// </summary>
        IGenericRepository<Service> Services { get; set; }

        /// <summary>
        /// Saves data to Database
        /// </summary>
        void Save();

        /// <summary>
        /// Release unmanaged resources used application
        /// </summary>
        void Dispose();
    }
}
