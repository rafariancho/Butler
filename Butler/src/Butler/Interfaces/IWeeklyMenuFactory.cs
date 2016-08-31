using Butler.Models;
using System.Collections.Generic;

namespace Butler.Interfaces
{
    public interface IWeeklyMenuFactory
    {
       List<DailyMenu> GetWeeklyMenu();
    }
}