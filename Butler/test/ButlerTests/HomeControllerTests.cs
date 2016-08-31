using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Interfaces;
using Butler.Factories;

namespace ButlerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private IWeeklyMenuFactory _WeeklyMenuFactory;

        [SetUp]
        public void Setup() {
            _WeeklyMenuFactory = new FakeWeeklyMenuFactory();
        }

        [Test]
        public void IndexShouldReturnSomething()
        {
            var homeController = new Butler.Controllers.HomeController(_WeeklyMenuFactory);
            var indexResult = homeController.Index() as ViewResult;
            Assert.That(indexResult.Model, Is.Not.Null);
        }

        [Test]
        public void IndexShouldReturnAWeeklyMenu()
        {
            var homeController = new Butler.Controllers.HomeController(_WeeklyMenuFactory);
            var indexResult = homeController.Index() as ViewResult;
            Assert.That(indexResult.Model, Is.InstanceOf(typeof(List<Butler.Models.DailyMenu>)));
        }
    }
}
