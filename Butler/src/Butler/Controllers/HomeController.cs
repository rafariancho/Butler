using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Butler.Models;
using Butler.Interfaces;

namespace Butler.Controllers
{
    public class HomeController : Controller
    {
        private IWeeklyMenuFactory _weeklyMenuFactory;

        public HomeController(IWeeklyMenuFactory weeklyMenuFactory)
        {
            _weeklyMenuFactory = weeklyMenuFactory;
        }
        public IActionResult Index()
        {   
            return View(_weeklyMenuFactory.GetWeeklyMenu());
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
