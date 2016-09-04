using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Interfaces;
using Butler.Factories;
using Butler.Repositories;
using Butler.Models;

namespace ButlerTests
{
    [TestFixture]
    public class WeeklyMenuFactoryTests
    {
        private FakeRepository _repository;
        const int LUNCHES_NUMBER = 10;

        [SetUp]
        public void Setup()
        {
            _repository = new FakeRepository();
            _repository.InMemoryDishes(CreateDishes(LUNCHES_NUMBER));
        }

        [Test]
        public void ShouldGenerateWeeklyMenu()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);
            
            var result = factory.GetWeeklyMenu();
            Assert.That(result, Is.InstanceOf<List<DailyMenu>>());
            Assert.That(result.Count, Is.EqualTo(7));
        }

        [Test]
        public void ShouldGenerateWeeklyMenuThatComesFromTheRepository()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);

            var result = factory.GetWeeklyMenu();

            Assert.That(result[0].Menu.Lunch.Name, Does.StartWith("Lunch"));
            Assert.That(result[0].Menu.Dinner.Name, Does.StartWith("Dinner"));
        }

        [Test]
        public void ShouldGenerateWeeklyMenuThatWontRepeatTwoConsecutiveLunches()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);
            
            var result = factory.GetWeeklyMenu();

            //Will apply only to the current week, next monday doesn´t count as repetition.
            Assert.That(result[0].Menu.Lunch.Name, Is.Not.EqualTo(result[1].Menu.Lunch.Name));
            Assert.That(result[1].Menu.Lunch.Name, Is.Not.EqualTo(result[2].Menu.Lunch.Name));
            Assert.That(result[2].Menu.Lunch.Name, Is.Not.EqualTo(result[3].Menu.Lunch.Name));
            Assert.That(result[3].Menu.Lunch.Name, Is.Not.EqualTo(result[4].Menu.Lunch.Name));
            Assert.That(result[4].Menu.Lunch.Name, Is.Not.EqualTo(result[5].Menu.Lunch.Name));
            Assert.That(result[5].Menu.Lunch.Name, Is.Not.EqualTo(result[6].Menu.Lunch.Name));
        }

        [Test]
        public void ShouldGenerateWeeklyMenuThatWontRepeatMoreThanTwoLunches()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);

            var result = factory.GetWeeklyMenu();
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[0].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[1].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[2].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[3].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[4].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[5].Menu.Lunch.Id).Count(), Is.LessThan(3));
            Assert.That(result.Where(x => x.Menu.Lunch.Id == result[6].Menu.Lunch.Id).Count(), Is.LessThan(3));
        }

        [Test]
        public void ShouldGenerateWeeklyMenuThatHasTwoLunchesWith4TuppersAtLeast()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);

            var result = factory.GetWeeklyMenu();
            Assert.That(result.Where(x => x.Menu.Lunch.Tuppers > 2).Count(), Is.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void ShouldEnsureThatTwo4TupperLunchesRepeatInTheWeeklyMenu()
        {
            IWeeklyMenuFactory factory = new WeeklyMenuFactory(_repository);

            var result = factory.GetWeeklyMenu();
            Assert.That(result.Where(x => x.Menu.Lunch.Tuppers > 2 && x.Menu.Lunch.Id == result[0].Menu.Lunch.Id).Count(), Is.GreaterThanOrEqualTo(2));
            Assert.That(result.Where(x => x.Menu.Lunch.Tuppers > 2 && x.Menu.Lunch.Id == result[1].Menu.Lunch.Id).Count(), Is.GreaterThanOrEqualTo(2));
        }

        private List<Dish> CreateDishes(int maxMenus)
        {
            var dishList = new List<Dish>();
            for (int i = 0; i < maxMenus; i++)
            {
                dishList.Add(new Dish()
                {
                    Id = i,
                    Name = "Lunch" + i,
                    Tuppers = 2 + (2 * (i % 2)), //2 or 4 tuppers
                    Type = Butler.Models.Type.Lunch,
                    Ingredients = new List<Ingredient> {
                                                                new Ingredient() {
                                                                                    Id = 1,
                                                                                    Amount = "1",
                                                                                    Product = new Product() {
                                                                                                                Id = 1,
                                                                                                                Name = "Onion",
                                                                                                                Unit = Unit.Amount
                                                                                    }
                                                                }
                                                            }
                });
            }
            for (int j = maxMenus; j < (maxMenus* 2); j++)
            {
                dishList.Add(new Dish()
                {
                    Id = j,
                    Name = "Dinner" + j,
                    Tuppers = 2 + (2 * (j % 2)), //2 or 4 tuppers
                    Type = Butler.Models.Type.Dinner,
                    Ingredients = new List<Ingredient> {
                                                                new Ingredient() {
                                                                                    Id = 1,
                                                                                    Amount = "1",
                                                                                    Product = new Product() {
                                                                                                                Id = 1,
                                                                                                                Name = "Onion",
                                                                                                                Unit = Unit.Amount
                                                                                    }
                                                                }
                                                            }
                });
            }
            return dishList;
        }
    }
}
