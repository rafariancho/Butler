using Butler.Extensions;
using Butler.Interfaces;
using Butler.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Repositories
{
    public class UserData : IPersistUserData
    {
        private ISession _session;

        public ISession Session
        {
            get
            {
                return _session;
            }

            set
            {
                _session = value;
            }
        }


        public UserData(){}

        public bool ExistsCurrentWeeksMenu(string key)
        {
            return Session.GetObjectFromJson<List<DailyMenu>>(key) != null;
        }

        public List<DailyMenu> GetCurrentWeeksMenu(string key)
        {
            return Session.GetObjectFromJson<List<DailyMenu>>(key);
        }

        public void StoreCurrentWeeksMenu(string key, List<DailyMenu> value)
        {
            Session.SetObjectAsJson(key, value);
        }
    }
}
