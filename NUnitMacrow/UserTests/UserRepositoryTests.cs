﻿using BiddingPlatform.Bid;
using BiddingPlatform.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitMacrow.UserTests
{
    internal class UserRepositoryTests
    {
        //private string connectionString = "Server=DESKTOP-P38TJBL\\SQLEXPRESS;Database=BiddingPlatformDB;Integrated Security=True;";
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BidingSystem;Integrated Security=True;";
        private UserRepository userRepository;

        [SetUp]
        public void Setup()
        {
            userRepository = new UserRepository(connectionString);
        }

        [TearDown]
        public void TearDown()
        {
            userRepository.ListOfUsers.Clear();
        }

        [Test]
        public void TestAddUserToRepo()
        {
            // Arrange
            IUserTemplate user = new BasicUser(1, "UserName", "User") as IUserTemplate;

            // Act
            userRepository.AddUserToRepo(user);

            // Assert
            List<IUserTemplate> users = userRepository.GetListOfUsers();
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.IsTrue(users.Contains(user));
        }

        [Test]
        public void TestRemoveUserFromRepo()
        {
            // Arrange
            IUserTemplate user = new BasicUser(1, "UserName", "User") as IUserTemplate;
            userRepository.AddUserToRepo(user);

            // Act
            userRepository.RemoveUserFromRepo(user);

            // Assert
            List<IUserTemplate> users = userRepository.GetListOfUsers();
            Assert.That(users.Count, Is.EqualTo(0));
            Assert.IsFalse(users.Contains(user));
        }

        [Test]
        public void TestUpdateUserIntoRepo()
        {
            // Arrange
            IUserTemplate oldUser = new BasicUser(1, "OldUserName", "OldUser") as IUserTemplate;
            IUserTemplate newUser = new BasicUser(1, "NewUserName", "NewUser") as IUserTemplate;
            userRepository.AddUserToRepo(oldUser);

            // Act
            userRepository.UpdateUserIntoRepo(oldUser, newUser);

            // Assert
            List<IUserTemplate> users = userRepository.GetListOfUsers();
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.IsFalse(users.Contains(oldUser));
            Assert.IsTrue(users.Contains(newUser));
        }

        [Test]
        public void TestGetListOfUsers()
        {
            // Arrange
            IUserTemplate user1 = new BasicUser(1, "UserName1", "User1") as IUserTemplate;
            IUserTemplate user2 = new BasicUser(2, "UserName2", "User2") as IUserTemplate;
            userRepository.AddUserToRepo(user1);
            userRepository.AddUserToRepo(user2);

            // Act
            List<IUserTemplate> users = userRepository.GetListOfUsers();

            // Assert
            Assert.That(users.Count, Is.EqualTo(2));
            Assert.IsTrue(users.Contains(user1));
            Assert.IsTrue(users.Contains(user2));
        }
    }
}
