using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>All services from database</returns>
        ICollection<UserDto> GetUsers();

        /// <summary>
        /// Gets user by his Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        UserDto GetUserByID(int id);

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="userDto">User which will be added</param>
        void AddUser(UserDto userDto);

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="id">User identifier</param>
        void RemoveUserByID(int id);

        /// <summary>
        /// Updates User with corresponding identifier
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="userDto">Updated user</param>
        void Updateuser(int id, UserDto userDto);
    }
}
