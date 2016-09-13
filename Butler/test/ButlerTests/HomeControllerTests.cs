using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Interfaces;
using Butler.Factories;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Net.Http;

namespace ButlerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private IWeeklyMenuFactory _WeeklyMenuFactory;
        private Mock<ControllerContext> _context;
        private Mock<HttpContext> _httpContext;

        [SetUp]
        public void Setup() {
            _WeeklyMenuFactory = new FakeWeeklyMenuFactory();
            var session = new Mock<ISession>();
            _httpContext = new Mock<HttpContext>();
            _httpContext.Setup(x => x.Session ).Returns(session.Object);
        }

        [Test]
        public void IndexShouldReturnSomething()
        {
            var homeController = new Butler.Controllers.HomeController(_WeeklyMenuFactory, new userDataFake());
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.Index() as ViewResult;

            Assert.That(indexResult.Model, Is.Not.Null);
        }

        [Test]
        public void IndexShouldReturnAWeeklyMenu()
        {
            var homeController = new Butler.Controllers.HomeController(_WeeklyMenuFactory, new userDataFake());
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.Index() as ViewResult;

            Assert.That(indexResult.Model, Is.InstanceOf(typeof(List<Butler.Models.DailyMenu>)));
        }        
    }
}
