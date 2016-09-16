using Butler.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Butler.Interfaces
{
    public interface IPersistUserData
    {
        ISession Session { get; set; }

        List<DailyMenu> GetCurrentWeeksMenu();
        void StoreCurrentWeeksMenu( List<DailyMenu> value);
        bool ExistsCurrentWeeksMenu();
    }
}