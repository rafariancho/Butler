using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Butler.Models;
using Butler.Interfaces;
using Butler.Extensions;

namespace Butler.Controllers
{
    public class HomeController : Controller
    {
        private IWeeklyMenuFactory _weeklyMenuFactory;

        public HomeController(IWeeklyMenuFactory weeklyMenuFactory)
        {
            _weeklyMenuFactory = weeklyMenuFactory;
        }

        //http://benjii.me/2015/07/using-sessions-and-httpcontext-in-aspnet5-and-mvc6/
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<List<DailyMenu>>("CurrentWeek") != null)
            {
                HttpContext.Session.SetObjectAsJson("CurrentWeek", _weeklyMenuFactory.GetWeeklyMenu());
            }
            return View(HttpContext.Session.GetObjectFromJson<List<DailyMenu>>("CurrentWeek"));
        }
        
        public IActionResult NewCurrentMenu()
        {
            HttpContext.Session.SetObjectAsJson("CurrentWeek", _weeklyMenuFactory.GetWeeklyMenu());
            return View(HttpContext.Session.GetObjectFromJson<List<DailyMenu>>("CurrentWeek"));
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
