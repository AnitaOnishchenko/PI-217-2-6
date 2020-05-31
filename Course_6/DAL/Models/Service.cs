using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Model of Service
    /// </summary>
    [Table("Services")]
    public class Service
    {
        /// <summary>
        /// Service identifier
        /// </summary>
        [Key]
        public int ServiceId { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Service price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Collection of users who bought this service
        /// </summary>
        public virtual ICollection<User> UsersWhoBought { get; set; }
    }
}
