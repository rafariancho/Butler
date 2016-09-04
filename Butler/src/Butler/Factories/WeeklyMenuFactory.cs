using Butler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Models;
using System.Diagnostics;

namespace Butler.Factories
{
    public class WeeklyMenuFactory : IWeeklyMenuFactory
    {
        private IRepository _repository;

        public WeeklyMenuFactory(IRepository repository)
        {
            _repository = repository;
        }
        public List<DailyMenu> GetWeeklyMenu()
        {
            List<Dish> dishes = _repository.GetDishes().ToList();
            Menu[] menus = new Menu[7];
            List<DailyMenu> weeklyMenu = new List<DailyMenu>();
            List<Dish> lunches4Tuppers = dishes.Where(x => x.Type == Models.Type.Lunch && x.Tuppers > 2).OrderBy(r => Guid.NewGuid()).Take(2).ToList();
            var lunches = dishes.Where(x=> x.Type == Models.Type.Lunch && (!lunches4Tuppers.Select(y => y.Id).Contains(x.Id))).OrderBy(r => Guid.NewGuid()).Take(7);
            var dinners = dishes.Where(x=> x.Type == Models.Type.Dinner).OrderBy(r => Guid.NewGuid()).Take(7);

            //Duplicated lunches in alternate days
            for (int i = 0; i < 2; i++)
            {
                menus[i] = new Menu() { Lunch = lunches4Tuppers[i], Dinner = dinners.FirstOrDefault() };
                dinners = dinners.Skip(1);
                menus[i +2] = new Menu() { Lunch = lunches4Tuppers[i], Dinner = dinners.FirstOrDefault() };
                dinners = dinners.Skip(1);
            }
            
            //Rest of menus
            for (int j = 4; j < 7; j++)
            {
                var lunchQuery =  lunches.SkipWhile(x => x.Id == menus[j-1].Lunch.Id);
                
                menus[j] = new Menu() { Lunch = lunchQuery.FirstOrDefault(), Dinner = dinners.FirstOrDefault() };
                dinners = dinners.Skip(1);
            }
            
            for (int k = 0; k < 7; k++)
            {
                DayOfWeek day = ((DayOfWeek)k + 1);
                weeklyMenu.Add(new DailyMenu() { Day = day.ToString(), Menu = menus[k]});
                Debug.WriteLine("Debug.WriteLine" + menus[k].Lunch.Id.ToString());
            }
            return weeklyMenu;
        }
    }
}