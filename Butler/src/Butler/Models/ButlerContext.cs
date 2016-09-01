using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Butler.Models
{
    public class ButlerContext: DbContext
    {
        public ButlerContext(DbContextOptions<ButlerContext> options): base(options)
        {}
        public DbSet<Dish> Dishes { get; set; }        
    }
}
