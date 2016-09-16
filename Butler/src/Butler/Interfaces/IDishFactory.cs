using Butler.Models;
using System.Collections.Generic;

namespace Butler.Interfaces
{
    public interface IDishFactory
    {
        Dish GetRandomDish(List<Dish> dishesNotToRepeat, Type mealType, int minTuppers);
    }
}