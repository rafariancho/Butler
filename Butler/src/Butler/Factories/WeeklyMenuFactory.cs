﻿using Butler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Models;

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
            List<Menu> menus = new List<Menu>();
            List<DailyMenu> weeklyMenu = new List<DailyMenu>();

            var lunches = dishes.Where(x=> x.Type == Models.Type.Lunch).OrderBy(r => Guid.NewGuid()).Take(7);
            var dinners = dishes.Where(x=> x.Type == Models.Type.Dinner).OrderBy(r => Guid.NewGuid()).Take(7);

            for (int i = 0; i < 7; i++)
            {
                //If i > 0 check if menu is repeating 
                var lunchQuery =  i>0 ? lunches.SkipWhile(x => x.Id == menus[i-1].Lunch.Id): lunches;

                //Check that the lunch is not repeting more than twice
                var currentLunchId = lunchQuery.FirstOrDefault().Id;
                int iCount = i;
                while ((menus.Where(x => x.Lunch.Id == currentLunchId).Count() >= 2) && (iCount > 0))
                {
                    lunchQuery = lunchQuery.SkipWhile(x => x.Id == currentLunchId);
                    iCount--;
                } 

                var lunch = lunchQuery.FirstOrDefault();
                var dinner = dinners.Skip(i).FirstOrDefault();

                Menu menu = new Menu() { Lunch = lunch, Dinner = dinner };
                menus.Add(menu);
                DayOfWeek day = ((DayOfWeek)i + 1);
                weeklyMenu.Add(new DailyMenu() { Day = day.ToString(), Menu = menu });
            }
            return weeklyMenu;
        }
    }
}