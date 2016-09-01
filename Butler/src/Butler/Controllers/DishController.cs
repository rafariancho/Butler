using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Butler.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Butler.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Butler.Controllers
{
    public class DishController : Controller
    {
        private IHostingEnvironment _environment;
        private IRepository _repository;

        public DishController(IHostingEnvironment environment, IRepository repository)
        {
            _environment = environment;
            _repository = repository;
        }

        public IActionResult Index() {
            return View(_repository.GetDishes());
        }
                
        public IActionResult Edit()
        {
            DishViewModel model = new ViewModels.DishViewModel();
            InitializeModel(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DishViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    if (model.Image.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, model.Image.FileName), FileMode.Create))
                        {
                            await model.Image.CopyToAsync(fileStream);
                        }
                    }
                    model.ImageSrc = "/uploads/" + model.Image.FileName;
                }
            }
            InitializeModel(model);
            return View(model);
        }
       
        private static void InitializeModel(DishViewModel model)
        {
            model.DishTypes = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            model.DishTypes.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Lunch", Value = "1" });
            model.DishTypes.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Dinner", Value = "2" });
            model.ConsistencyTypes = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            model.ConsistencyTypes.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Heavy", Value = "1" });
            model.ConsistencyTypes.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Normal", Value = "2" });
            model.ConsistencyTypes.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "Light", Value = "3" });
        }
    }
}
