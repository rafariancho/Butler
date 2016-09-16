using System;
using System.Collections.Generic;
using Butler.Interfaces;
using Butler.Models;
using System.Linq;

namespace Butler.Factories
{
    internal class DishFactory : IDishFactory
    {
        private IRepository _repository;

        public DishFactory(IRepository repository)
        {
            _repository = repository;
        }

        public Dish GetRandomDish(List<Dish> dishesNotToRepeat, Models.Type mealType, int minTuppers)
        {
            return _repository.GetDishes().Where(x => ! dishesNotToRepeat.Select(y => y.Id).Contains(x.Id)
                                                    && x.Type == mealType
                                                    && x.Tuppers >= minTuppers)
                                          .OrderBy(r => Guid.NewGuid()).FirstOrDefault();
        }
    }
}