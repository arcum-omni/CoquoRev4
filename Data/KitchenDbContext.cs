using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoquoRev4.Data
{
    public class KitchenDbContext : IdentityDbContext
    {
        public KitchenDbContext(DbContextOptions<KitchenDbContext> options) : base(options)
        {
        }
    }
}
