using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butler.Extensions
{
    public static class EnumUtil
    {
        public static IEnumerable<SelectListItem> EnumToList<T>(int selectedValue) where T : struct
        {
            List<SelectListItem> list = new List<SelectListItem>();
            
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToArray<T>();
            var names = Enum.GetNames(typeof(T)).Cast<string>().ToArray<string>();
            for (int ivalue = 0; ivalue < values.Count(); ivalue++) {
                list.Add(new SelectListItem() {
                    Value = values[ivalue].ToString(),
                    Text = names[ivalue],
                    Selected = (Convert.ToInt32(values[ivalue]) == selectedValue)
                });
            }
            return list;
        }
    }
}
