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
using Butler.Models;
using ButlerTests.Fakes;
using Butler;

namespace ButlerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private IWeeklyMenuFactory _WeeklyMenuFactory;
        private Mock<ControllerContext> _context;
        private Mock<HttpContext> _httpContext;
        private FakeDishFactory _DishFactory;
        private FakeUserData _userData;

        [SetUp]
        public void Setup() {
            _WeeklyMenuFactory = new FakeWeeklyMenuFactory();
            _DishFactory = new FakeDishFactory();
            var session = new Mock<ISession>();
            _httpContext = new Mock<HttpContext>();
            _httpContext.Setup(x => x.Session ).Returns(session.Object);

            _userData = new FakeUserData();
            _userData.sessionId = Guid.NewGuid().ToString();
        }

        [Test]
        public void Index_ShouldReturn_Something()
        {
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.Index() as ViewResult;

            Assert.That(indexResult.Model, Is.Not.Null);
        }

        [Test]
        public void Index_ShouldReturn_AWeeklyMenu()
        {
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.Index() as ViewResult;

            Assert.That(indexResult.Model, Is.InstanceOf(typeof(List<Butler.Models.DailyMenu>)));
        }  

        [Test]
        public void NewMenu_ShouldReturn_Something()
        {
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.NewCurrentMenu() as ViewResult;

            Assert.That(indexResult.Model, Is.Not.Null);
        }

        [Test]
        public void NewMenu_ShouldReturn_AWeeklyMenu()
        {
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.NewCurrentMenu() as ViewResult;

            Assert.That(indexResult.Model, Is.InstanceOf(typeof(List<Butler.Models.DailyMenu>)));
        }    

        [Test]
        public void NewDish_ShouldReturn_Something()
        {
            _userData.StoreCurrentWeeksMenu(_WeeklyMenuFactory.GetWeeklyMenu());
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.NewDish(_userData.GetCurrentWeeksMenu().First().Menu.Lunch.Id) as ViewResult;

            Assert.That(indexResult.Model, Is.Not.Null);
        }

        [Test]
        public void NewDish_ShouldReturn_AWeeklyMenu()
        {
            _userData.StoreCurrentWeeksMenu(_WeeklyMenuFactory.GetWeeklyMenu());
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;

            var indexResult = homeController.NewDish(_userData.GetCurrentWeeksMenu().First().Menu.Lunch.Id) as ViewResult;

            Assert.That(indexResult.Model, Is.InstanceOf(typeof(List<Butler.Models.DailyMenu>)));
        }    

        [Test]
        public void NewDish_ShouldReturn_AWeeklyMenuWithANewDishOnIt()
        {
            _userData.StoreCurrentWeeksMenu(_WeeklyMenuFactory.GetWeeklyMenu());
            var homeController = new HomeController(_WeeklyMenuFactory, _DishFactory, _userData);
            homeController.ControllerContext.HttpContext = _httpContext.Object;
            int lunchId = _userData.GetCurrentWeeksMenu().First().Menu.Lunch.Id;

            var indexResult = homeController.NewDish(lunchId) as ViewResult;

            Assert.That(((List<DailyMenu>)indexResult.Model).First().Menu.Lunch.Id, Is.Not.EqualTo(lunchId));
        } 
    }
}
