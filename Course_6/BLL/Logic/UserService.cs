using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    /// <summary>
    /// Service for agency users
    /// </summary>
    internal class UserService : IUserService
    {
        /// <summary>
        /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Transforms an input object of one type into an output object of a different type
        /// </summary>
        private readonly IMapper _userMapper;

        /// <summary>
        /// Transforms an input object of one type into an output object of a different type
        /// </summary>
        private readonly IMapper _userUpdateMapper;

        /// <summary>
        ///  Creates instance of <see cref="UserService"/>
        /// </summary>
        /// <param name="unitOfWork">Maintains a list of objects affected by a business
        /// transaction and coordinates the writing out of changes</param>
        public UserService(IUnitOfWork unitOfWork)
        {
            _userMapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()
            .ForMember(x => x.Services, y => y.Ignore()).ForMember(x => x.Role, y => y.Ignore())).CreateMapper();

            _userUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, User>()
            .ForMember(x => x.Services, y => y.Ignore()).ForMember(x => x.Role, y => y.Ignore())).CreateMapper();

            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="userDto">User which will be added</param>
        public void AddUser(UserDto userDto)
        {
            _unitOfWork.Users.Create(new User { Name = userDto.Name, Login = userDto.Login, Pass = userDto.Pass, RoleId = userDto.RoleId });
            _unitOfWork.Save();
        }

        /// <summary>
        /// Gets user by his Id
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns></returns>
        public UserDto GetUserByID(int id)
        {
            return _userMapper.Map<User, UserDto>(_unitOfWork.Users.GetOne(x => (x.UserId == id)));
        }

        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>All services from database</returns>
        public ICollection<UserDto> GetUsers()
        {
            return _userMapper.Map<IEnumerable<User>, List<UserDto>>(_unitOfWork.Users.Get());
        }

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="id">User identifier</param>
        public void RemoveUserByID(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
            _unitOfWork.Save();
        }

        /// <summary>
        /// Updates User with corresponding identifier
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="userDto">Updated user</param>
        public void Updateuser(int id, UserDto userDto)
        {
            var userForUpdate = GetUserByID(id);

            if (userForUpdate != null)
            {
                _unitOfWork.Users.Update(_userUpdateMapper.Map<UserDto, User>(userDto));
            }
        }
    }
}
