using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Model of Role
    /// </summary>
    [Table("Roles")]
    public class Role
    {
        /// <summary>
        /// Role identifier
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string RoleName { get; set; }
    }
}
