using System;
using NUnit.Framework;
using Blossom.Data.Model;
using Blossom.Data.Implementation.Users;
using Blossom.Service.Implementation.Users;
using AutoMapper;
using Blossom.Mapping;
using Blossom.Service.Model.Users;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Blossom.Data.Users;
using Blossom.Service.Users;

namespace Blossom.Service.Implementation.Test
{
    [TestFixture]
    public class UserServiceTest: ServiceFactoryTest
    {
        private IUserService _userService;
        private IUserRepository _userRepository;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            _userRepository = new UserRepository(_factory);
            _userService = new UserService(_mapper, _userRepository);
        }

        [Test]
        public void TestUserCreated()
        {
            //Setup
            var g = Guid.NewGuid();
            var user = new User() { Id = g, Name = "Alexander Mitrakis", Email = "alex@mitrakis.net", AuthId = "amitrakis" };

            //Act
            var userCreated = _userService.CreateUser(user);

            //Assert
            Assert.NotNull(userCreated, "User should not be null");
            var userQuery = _userService.GetById(g);
            Assert.NotNull(userQuery, "User should be in Database");
        }

        [Test]
        public void TestGetAllUsers()
        {
            //Setup
            for (var i = 0; i < 100; i++)
			{
                var g = Guid.NewGuid();
                var user = new User() { Id = g, Name = "Alexander Mitrakis", Email = "alex@mitrakis.net", AuthId = $"amitrakis{i}" };
                _userService.CreateUser(user);
            }

            //Act
            var userQuery = _userService.GetAll();

            //Assert
            Assert.AreEqual(100, userQuery.Count, "User should be Created");
        }

        [Test]
        public void TestUpdateUser()
        {
            //Setup
            var g = Guid.NewGuid();
            var user = new User() { Id = g, Name = "Alexander Mitrakis", Email = "alex@mitrakis.net", AuthId = "amitrakis" };
            var userCreated = _userService.CreateUser(user);

            //Act
            userCreated.Name = "Test Name";
            userCreated.Email = "Test@test.com";
            _userService.UpdateUser(userCreated);

            //Assert
            var userQuery = _userService.GetById(g);
            Assert.NotNull(userQuery, "User should be in Database");
            Assert.AreEqual("Test Name", userQuery.Name);
            Assert.AreEqual("Test@test.com", userQuery.Email);
        }

        [Test]
        public void TestDeleteUser()
        {
            //Setup
            var g = Guid.NewGuid();
            var user = new User() { Id = g, Name = "Alexander Mitrakis", Email = "alex@mitrakis.net", AuthId = "amitrakis" };
            var userCreated = _userService.CreateUser(user);

            //Act
            _userService.DeleteUser(g);

            //Assert
            var userQuery = _userService.GetById(g);
            Assert.Null(userQuery, "User should be removed");
        }
    }
}