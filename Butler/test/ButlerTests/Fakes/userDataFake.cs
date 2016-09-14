using System;
using System.Collections.Generic;
using Butler.Interfaces;
using Butler.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ButlerTests
{
    internal class userDataFake : IPersistUserData
    {
        public ISession Session
        {
            get;
            set;
        }

        private Dictionary<string, string> sessionFake = new Dictionary<string, string>();

        public bool ExistsCurrentWeeksMenu(string key)
        {
            return sessionFake.GetObjectFromJson<List<DailyMenu>>(key) != null;
        }

        public List<DailyMenu> GetCurrentWeeksMenu(string key)
        {
            return sessionFake.GetObjectFromJson<List<DailyMenu>>(key);
        }

        public void StoreCurrentWeeksMenu(string key, List<DailyMenu> value)
        {
            sessionFake.SetObjectAsJson(key, value);
        }        
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this Dictionary<string, string> session, string key, object value)
        {
            session.Add(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this Dictionary<string, string> session, string key)
        {
            string value = null;
            session.TryGetValue(key, out value);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}