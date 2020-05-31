using System.Collections.Generic;
using BLL.Logic;
using DAL.Models;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BLL.DTO;
using DAL;
using System;

namespace Unit_Tests
{
    /// <summary>
    /// Tests fo <see cref="ServiceService"/>
    /// </summary>
    [TestClass]
    public class ServiceServiceTests
    {
        /// <summary>
        /// Service for agency services
        /// Defines properties and methods for agency services
        /// </summary>
        private IServiceService _serviceService;
        private IUserService _userService;

        /// <summary>
        /// Provides a mock implementation of IUnitOfWork
        /// </summary>
        private Mock<UnitOfWork> _unitOfWork;

        /// <summary>
        ///  Provides a mock implementation of IGenericRepository
        /// </summary>
        private Mock<IGenericRepository<Service>> _serviceRepository;
        private Mock<IGenericRepository<User>> _userRepository;

        /// <summary>
        /// Collection of services and users
        /// </summary>
        private List<Service> services;
        private List<User> users;

        [TestInitialize]
        public void Initialize()
        {
            _serviceRepository = new Mock<IGenericRepository<Service>>();
            _userRepository = new Mock<IGenericRepository<User>>();
            var roleRepository = new Mock<IGenericRepository<Role>>();
            var agencyContext = new Mock<AgencyContext>();

            _unitOfWork = new Mock<UnitOfWork>(agencyContext.Object, roleRepository.Object, _userRepository.Object, _serviceRepository.Object);

            _serviceService = new ServiceService(_unitOfWork.Object);
            _userService = new UserService(_unitOfWork.Object);
        }


        /// <summary>
        /// Tests that GetServices() returns correct number of services
        /// </summary>
        [TestMethod]
        public void GetServices_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            services = new List<Service>
            {
                new Service(){Name ="First"},
                 new Service(){Name ="Second"},
                  new Service(){Name ="Third"},

            };

            _serviceRepository.Setup(x => x.Get()).Returns(services);

            //Act
            var result = _serviceService.GetServices();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }


        /// <summary>
        /// Tests that GetUsers() returns correct number of users
        /// </summary>
        [TestMethod]
        public void GetUsers_ReturnsCorrectNumberOfUsers()
        {
            //Arrange
            users = new List<User>
            {
                new User(){Name ="First"},
                 new User(){Name ="Second"},
                  new User(){Name ="Third"},
            };

            _userRepository.Setup(x => x.Get()).Returns(users);

            //Act
            var result = _userService.GetUsers();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// Tests that AddService() calls Create() method with specified parameter
        /// </summary>
        [TestMethod]
        public void AddService_CalledCreateMethod()
        {
            //Arrange
            _serviceRepository.Setup(x => x.Create(It.IsAny<Service>()));

            //Act
            _serviceService.AddService(new ServiceDto());

            //Assert
            _serviceRepository.Verify(x => x.Create(It.IsAny<Service>()), Times.Once);
        }

        /// <summary>
        /// Tests that AddUser() calls Create() method with specified parameter
        /// </summary>
        [TestMethod]
        public void AddUser_CalledCreateMethod()
        {
            //Arrange
            _userRepository.Setup(x => x.Create(It.IsAny<User>()));

            //Act
            _userService.AddUser(new UserDto());

            //Assert
            _userRepository.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        /// <summary>
        /// Tests that UpdateService() calls Update() method with specified parameter
        /// </summary>
        [TestMethod]
        public void UpdateService_CalledUpdateMethod()
        {
            //Arrange
            _serviceRepository.Setup(x => x.GetOne(It.IsAny<Func<Service, bool>>()))
                .Returns(new Service() { ServiceId = 1, Name = "First" });

            _serviceRepository.Setup(x => x.Update(It.IsAny<Service>()));

            //Act
            _serviceService.UpdateService(1, new ServiceDto());

            //Assert
            _serviceRepository.Verify(x => x.Update(It.IsAny<Service>()), Times.Once);
        }

        /// <summary>
        /// Tests that GetServiceByID() returns correct service
        /// </summary>
        [TestMethod]
        public void GetServiceByID_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            var expectedService = new Service() { ServiceId = 1, Name = "First" };
            _serviceRepository.Setup(x => x.GetOne(It.IsAny<Func<Service, bool>>()))
               .Returns(expectedService);

            //Act
            var result = _serviceService.GetServiceByID(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.ServiceId, result.ServiceId);
            Assert.AreEqual(expectedService.Name, result.Name);
        }

        /// <summary>
        /// Tests that GetUserByID() returns correct service
        /// </summary>
        [TestMethod]
        public void GetUserByID_ReturnsCorrectNumberOfUsers()
        {
            //Arrange
            var expectedUser = new User() { UserId = 1, Name = "First" };
            _userRepository.Setup(x => x.GetOne(It.IsAny<Func<User, bool>>()))
               .Returns(expectedUser);

            //Act
            var result = _userService.GetUserByID(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.UserId, result.UserId);
            Assert.AreEqual(expectedUser.Name, result.Name);
        }

        /// <summary>
        /// Tests that GetServiceByID() calls Remove() method with specified parameter
        /// </summary>
        [TestMethod]
        public void RemoveServiceByID_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            var expectedService = new Service() { ServiceId = 1, Name = "First" };
            _serviceRepository.Setup(x => x.Remove(expectedService));

            //Act
            _serviceService.RemoveServiceByID(1);

            //Assert
            _serviceRepository.Verify(x => x.Remove(It.IsAny<Service>()), Times.Once);
        }
    }
}