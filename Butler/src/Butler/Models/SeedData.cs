using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Butler.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ButlerContext(serviceProvider.GetRequiredService<DbContextOptions<ButlerContext>>()))
            {
                // Look for any movies.
                if (context.Dishes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Dishes.AddRange(
                     new Dish
                     {
                         Name = "Patatas con chorizo",
                         Consistency = 1, //Heavy
                         Tuppers = 4,
                         Type = 1, //Lunch
                         Description = "se mezcla todo y se le prende fuego."
                     },

                     new Dish
                     {
                         Name = "Ragú de ternera",
                         Consistency = 1, //Heavy
                         Tuppers = 4,
                         Type = 1, //Lunch
                         Description = "se mezcla todo y se le prende fuego. 'Veneno amasao'"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
