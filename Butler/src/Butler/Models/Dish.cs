using System.Collections.Generic;

namespace Butler.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}