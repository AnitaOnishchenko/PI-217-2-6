using BLL.Logic;
using System.Collections.Generic;
using System.Web.Http;
using BLL.DTO;

namespace Course_6.Controllers
{
    /// <summary>
    /// Defines properties and methods for User controller
    /// </summary>
    public class UsersController : ApiController
    {
        /// <summary>
        /// Service for agency users
        /// Defines properties and methods for agency services
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Creates instance of <see cref="UsersController"/>
        /// </summary>
        /// <param name="serviceService">Service for agency users</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        public IEnumerable<UserDto> Get()
        {
            return _userService.GetUsers();
        }

        // GET: api/Users/5
        public UserDto Get(int id)
        {
            return _userService.GetUserByID(id);
        }

        // POST: api/Users
        public void Post([FromBody]UserDto user)
        {
            _userService.AddUser(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]UserDto user)
        {
            _userService.Updateuser(id, user);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            _userService.RemoveUserByID(id);
        }
    }
}
