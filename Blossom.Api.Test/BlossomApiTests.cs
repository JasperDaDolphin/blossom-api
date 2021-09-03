using System;
using NUnit.Framework;
using System.Data.Common;
using System.Data;
using System.Net.Http;
using Moq;
using Microsoft.Extensions.Hosting;

namespace Blossom.Api.Test
{
    [TestFixture]
    public abstract class ServiceFactoryTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestApi()
        {
            //var mockRepo = new Mock<IBrainstormSessionRepository>();
            //mockRepo.Setup(repo => repo.ListAsync())
            //    .ReturnsAsync(GetTestSessions());
            //var controller = new UsersController(mockRepo.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}