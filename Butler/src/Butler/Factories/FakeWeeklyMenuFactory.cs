using Butler.Interfaces;
using Butler.Models;
using System.Collections.Generic;

namespace Butler.Factories
{
    public class FakeWeeklyMenuFactory : IWeeklyMenuFactory
    {
        public List<DailyMenu> GetWeeklyMenu()
        {
            var weeklyMenu = new List<DailyMenu>();
            Menu menu = new Menu()
            {
                Dinner = new Dish()
                {
                    Id = 1,
                    Name = "Fosho con fatatas fritas",
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
                },
                Lunch = new Dish()
                {
                    Id = 1,
                    Name = "Fosho con fatatas fritas",
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
                }
            };
            weeklyMenu.Add(new DailyMenu() { Day = "Monday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Tuesday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Wednesday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Thursday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Friday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Saturday", Menu = menu });
            weeklyMenu.Add(new DailyMenu() { Day = "Sunday", Menu = menu });
            return weeklyMenu;
        }
    }
}