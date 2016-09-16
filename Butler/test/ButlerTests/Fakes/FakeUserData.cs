using System;
using System.Collections.Generic;
using Butler.Interfaces;
using Butler.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ButlerTests.Fakes
{
    internal class FakeUserData : IPersistUserData
    {
        public ISession Session
        {
            get;
            set;
        }

        private Dictionary<string, string> sessionFake = new Dictionary<string, string>();
        public string sessionId;

        public bool ExistsCurrentWeeksMenu()
        {
            return sessionFake.GetObjectFromJson<List<DailyMenu>>(sessionId) != null;
        }

        public List<DailyMenu> GetCurrentWeeksMenu()
        {
            return sessionFake.GetObjectFromJson<List<DailyMenu>>(sessionId);
        }

        public void StoreCurrentWeeksMenu( List<DailyMenu> value)
        {
            sessionFake.Remove(sessionId);
            sessionFake.SetObjectAsJson(sessionId, value);
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