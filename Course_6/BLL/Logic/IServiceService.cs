using DAL.Models;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency services
    /// Defines properties and methods for agency services
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Gets all services from database
        /// </summary>
        /// <returns>All services from database</returns>
        ICollection<ServiceDto> GetServices();

        /// <summary>
        /// Gets service by it's Id
        /// </summary>
        /// <param name="id">Service identifier</param>
        /// <returns></returns>
        ServiceDto GetServiceByID(int id);

        /// <summary>
        /// Adds service to database
        /// </summary>
        /// <param name="serviceDto">Service which will be added</param>
        void AddService(ServiceDto serviceDto);

        /// <summary>
        /// Updates Service with corresponding identifier
        /// </summary>
        /// <param name="id">Service identifier</param>
        /// <param name="serviceDto">Data transfer object for <see cref="Service"/></param>
        void UpdateService(int id, ServiceDto serviceDto);

        /// <summary>
        /// Removes services from database
        /// </summary>
        /// <param name="id">Service identifier</param>
        void RemoveServiceByID(int id);

        /// <summary>
        /// Provides logic for selling service
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="serviceId">Service identifier</param>
        /// <returns></returns>
        bool SellService(int userId, int serviceId);
    }
}
