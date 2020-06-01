using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalaxyTest.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }
}
