using Butler.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> DishTypes { set; get; }  
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ConsistencyTypes { set; get; }  
        [Required]
        [StringLength(100, MinimumLength = 20,ErrorMessage = "Name must be 20 to 100 characters long")]
        public String Name { get; set; }
        [Required]
        public int Tuppers { get; set; }
        [Required]
        public Models.Type Type { get; set; }
        [Required]
        public Consistency Consistency { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Preparation method must be 20 to 1000 characters long")]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string ImageSrc { get; set; }

        public void Map(Dish dish) {
            this.Id = dish.Id;
            this.Name = dish.Name;
            this.Tuppers = dish.Tuppers;
            this.Type = dish.Type;
            this.ImageSrc = dish.ImageSrc;
            this.Description = dish.Description;
            this.Consistency = dish.Consistency;
        }
        public Dish MapTo(Dish dish) {
            dish.Id = this.Id;
            dish.Name = this.Name;
            dish.Tuppers = this.Tuppers;
            dish.Type = this.Type;
            dish.ImageSrc = this.ImageSrc;
            dish.Description = this.Description;
            dish.Consistency = this.Consistency;
            return dish;
        }
    }
}
