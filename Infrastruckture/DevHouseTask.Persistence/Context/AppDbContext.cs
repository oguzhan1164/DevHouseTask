using DevHouseTask.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<Auth,Role,int>
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Database=DevHouseTaskDb;User=root;Password=ergin123;Port=3307;");
            }
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Page> Pages{ get; set; }
        public DbSet<PermissionDetail> PermissionDetails{ get; set; }
        public DbSet<User> Users{ get; set; }

    }
}
