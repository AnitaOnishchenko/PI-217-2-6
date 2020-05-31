using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;

namespace Course_6.Controllers
{
    public class BuyController : ApiController
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
        public BuyController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/Buy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Buy/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Buy
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Buy/5
        public void Put(int id, [FromBody]int serviceId)
        {
            _serviceService.SellService(id, serviceId);
        }

        // DELETE: api/Buy/5
        public void Delete(int id)
        {
        }
    }
}
