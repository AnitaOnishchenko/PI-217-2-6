using DAL.Models;

namespace BLL.DTO
{
    /// <summary>
    /// Data transfer object for <see cref="Role"/>
    /// </summary>
    public class RoleDto
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
