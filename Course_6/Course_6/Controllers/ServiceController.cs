using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;
using BLL.DTO;

namespace Course_6.Controllers
{
    /// <summary>
    /// Defines properties and methods for Service controller
    /// </summary>
    public class ServiceController : ApiController
    {
        /// <summary>
        /// Service for agency services
        /// Defines properties and methods for agency services
        /// </summary>
        private readonly IServiceService _serviceService;

        /// <summary>
        /// Creates instance of <see cref="ServiceController"/>
        /// </summary>
        /// <param name="serviceService">Service for agency services</param>
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/Service
        public IEnumerable<ServiceDto> Get()
        {
            return _serviceService.GetServices();
        }

        // GET: api/Service/5
        public ServiceDto Get(int id)
        {
            return _serviceService.GetServiceByID(id);
        }

        // POST: api/Service
        public void Post([FromBody]ServiceDto service)
        {
            _serviceService.AddService(service);
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]ServiceDto service)
        {
            _serviceService.UpdateService(id, service);
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
            _serviceService.RemoveServiceByID(id);
        }
    }
}
