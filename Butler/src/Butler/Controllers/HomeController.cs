using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Butler.Interfaces;

namespace Butler
{
    public class HomeController : Controller
    {
        private IWeeklyMenuFactory _weeklyMenuFactory;
        private IPersistUserData _userData;
        private IDishFactory _dishFactory;

        public HomeController(IWeeklyMenuFactory weeklyMenuFactory, IDishFactory dishFactory, IPersistUserData userData)
        {
            _weeklyMenuFactory = weeklyMenuFactory;
            _dishFactory = dishFactory;
            _userData = userData;
        }
        
        public IActionResult Index()
        {
            _userData.Session = HttpContext.Session;

            if (!_userData.ExistsCurrentWeeksMenu())
            {
                _userData.StoreCurrentWeeksMenu( _weeklyMenuFactory.GetWeeklyMenu());
            }
            return View(_userData.GetCurrentWeeksMenu());
        }
        
        public IActionResult NewCurrentMenu()
        {
            _userData.Session = HttpContext.Session;

            _userData.StoreCurrentWeeksMenu(_weeklyMenuFactory.GetWeeklyMenu());
            return View("Index", _userData.GetCurrentWeeksMenu());
        }

        public IActionResult NewDish(int id)
        {
            _userData.Session = HttpContext.Session;

            var menu = _userData.GetCurrentWeeksMenu();
            var lunches = menu.Select(x => x.Menu.Lunch).ToList();
            var dish = _dishFactory.GetRandomDish(lunches, Models.Type.Lunch, menu.Where(x => x.Menu.Lunch?.Id == id).Count() * 2);
            foreach (var dailyMenu in menu.Where(x => x.Menu.Lunch?.Id == id))
            {
                dailyMenu.Menu.Lunch = dish;
            }

            _userData.StoreCurrentWeeksMenu( menu);

            //return View("Index", _userData.GetCurrentWeeksMenu());
            return RedirectToAction("Index");
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
