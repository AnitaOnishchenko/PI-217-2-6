using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Model of User
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// User identifier
        /// </summary>
        [Key]
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
        public virtual Role Role { get; set; }

        /// <summary>
        /// Collection of services which were bought by this user
        /// </summary>
        public virtual ICollection<Service> Services { get; set; }
    }
}
