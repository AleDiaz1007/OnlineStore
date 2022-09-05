using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Context
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) 
            : base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Role> Role { get; set;}

        public virtual DbSet<Users> Users { get; set; }
    }
}
