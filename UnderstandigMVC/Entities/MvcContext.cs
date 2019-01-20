using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandigMVC.Entities
{
                                //Identity er til login                //Bruger DBcontext hvis vi ikke skal bruge identity
    public class MvcContext :  IdentityDbContext<IdentityUser>         //DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
