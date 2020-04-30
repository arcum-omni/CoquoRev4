using System;
using System.Collections.Generic;
using System.Text;
using CoquoRev4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoquoRev4.Data
{
    public class KitchenDbContext : IdentityDbContext
    {
        public KitchenDbContext(DbContextOptions<KitchenDbContext> options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
