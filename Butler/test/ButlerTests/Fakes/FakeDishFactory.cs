using System;
using System.Collections.Generic;
using Butler.Interfaces;
using Butler.Models;

namespace ButlerTests.Fakes
{
    internal class FakeDishFactory : IDishFactory
    {
        public Dish GetRandomDish(List<Dish> dishesNotToRepeat, Butler.Models.Type mealType, int minTuppers)
        {
            return new Dish()
            {
                Id = 1000,
                Name = "Lunch",
                Tuppers = 2, 
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
            };
        }
    }
}