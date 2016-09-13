using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Butler.Models;
using Butler.Interfaces;
using Butler.Extensions;

namespace Butler.Controllers
{
    public class HomeController : Controller
    {
        private IWeeklyMenuFactory _weeklyMenuFactory;
        private IPersistUserData _userData;

        public HomeController(IWeeklyMenuFactory weeklyMenuFactory, IPersistUserData userData)
        {
            _weeklyMenuFactory = weeklyMenuFactory;
            _userData = userData;
        }
        
        public IActionResult Index()
        {
            _userData.Session = HttpContext.Session;

            if (!_userData.ExistsCurrentWeeksMenu("CurrentWeek"))
            {
                _userData.StoreCurrentWeeksMenu("CurrentWeek", _weeklyMenuFactory.GetWeeklyMenu());
            }
            return View(_userData.GetCurrentWeeksMenu("CurrentWeek"));
        }
        
        public IActionResult NewCurrentMenu()
        {
            _userData.Session = HttpContext.Session;

            _userData.StoreCurrentWeeksMenu("CurrentWeek", _weeklyMenuFactory.GetWeeklyMenu());
            return View("Index", _userData.GetCurrentWeeksMenu("CurrentWeek"));
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
