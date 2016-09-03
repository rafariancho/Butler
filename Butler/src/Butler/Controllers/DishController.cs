using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Butler.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Butler.Interfaces;
using System;
using DataTables.AspNet.Core;
using System.Linq;

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
            return View();
        }

        [HttpPost]
        public JsonResult Returndata(DataTableParameters request)
        {           
            var filteredData = String.IsNullOrWhiteSpace(request.Search?.Value)
                ? _repository.GetDishes(request.Start, request.Length)
                : _repository.GetDishes(request.Search.Value, request.Start, request.Length);
            
                switch (request.Order[0]?.Column)
                {
                    case 1:
                        filteredData = request.Order[0]?.Dir == "asc"? filteredData.OrderBy(x => x.Name): filteredData.OrderByDescending(x => x.Name); break;
                    case 2:
                        filteredData = request.Order[0]?.Dir == "asc" ? filteredData.OrderBy(x => x.Tuppers) : filteredData.OrderByDescending(x => x.Tuppers); break;
                default:
                        break;
                }                

            return Json(new DataTablesResponse(request.Draw, filteredData, filteredData.Count(), _repository.GetDishesCount()));
        }

        public IActionResult Edit()
        {
            DishViewModel model = new DishViewModel();
            InitializeModel(model);
            return View(model);
        }

        [Route("/Dish/Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dish = _repository.GetDish(id);
            DishViewModel model = new DishViewModel();
            model.Map(dish);
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
                _repository.UpdateDish(model.MapTo(_repository.GetDish(model.Id)));
                _repository.Save();
                return RedirectToAction("Index");
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
