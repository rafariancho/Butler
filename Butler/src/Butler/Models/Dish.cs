using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Butler.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Name must be 20 to 100 characters long")]
        public string Name { get; set; }
        [Required]
        public int Tuppers { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int Consistency { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Preparation method must be 20 to 1000 characters long")]
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}