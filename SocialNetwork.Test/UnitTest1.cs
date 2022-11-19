using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using NUnit.Framework;
using SocialNetwork;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.Models;

namespace SocialNetwork.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegistrUserTest()
        {
            var userService = new UserService();
            var userRegistrationData = new UserRegistrationData()
            {
                FirstName = "Pavel",
                LastName = "Pavlov",
                Email = "pavel@ya.ru",
                Password = "40404040"
            };

            try
            {
                userService.Register(userRegistrationData);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void AddFriendTest()
        {
            var friendAdddata = new FriendAddData()
            {
                FriendEmail = "petr@ya.ru",
                UserId = 1,
            };
            FriendService friendService = new FriendService();

            try
            {
                friendService.Add(friendAdddata);
            }
            catch (Exception e)
            {
                Assert.Fail();
            } 
        }
        [Test]
        public void DeleteFriendTest()
        {
            var frienDeleteFData = new FriendDeleteData()
            {
                UserID = 1,
                FriendEmail = "petr@ya.ru",
                FrienId = 3,
            };

        var friendService = new FriendService();
            try
            {
                friendService.Delete(frienDeleteFData);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }
    }
}