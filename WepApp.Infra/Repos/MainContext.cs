using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApp.Domain.Entities;

namespace WepApp.Infra.Repos
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
