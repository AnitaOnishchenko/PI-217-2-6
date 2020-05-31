using System.Collections.Generic;
using DAL.Models;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for <see cref="User"/>
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// User's role id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// User's role
        /// </summary>
        public virtual RoleDto Role { get; set; }

        /// <summary>
        /// Collection of services which were bought by this user
        /// </summary>
        public virtual ICollection<ServiceDto> Services { get; set; }
    }
}
