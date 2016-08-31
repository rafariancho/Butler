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
        [MaxLength(200,ErrorMessage = "Name is too long")]
        [MinLength(10,ErrorMessage = "Name is too short")]
        public String Name { get; set; } 
        public int Tuppers { get; set; }  
        public int Type { get; set; }    
        public int Consistency { get; set; } 
        public IFormFile Image { get; set; }
        public string ImageSrc { get; set; }
    }
}
