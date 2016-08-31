using Butler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Butler.Models;

namespace Butler.Factories
{
    public class WeeklyMenuFactory : IWeeklyMenuFactory
    {
        public List<DailyMenu> GetWeeklyMenu()
        {
            var weeklyMenu = new List<DailyMenu>();
            return weeklyMenu;
        }
    }
}