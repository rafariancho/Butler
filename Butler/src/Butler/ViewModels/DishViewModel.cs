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
        public int Type { get; set; }
        [Required]
        public int Consistency { get; set; } 
        public IFormFile Image { get; set; }
        public string ImageSrc { get; set; }
    }
}
