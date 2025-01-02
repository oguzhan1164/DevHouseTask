using DevHouseTask.Application.Interfaces.Repositories;
using DevHouseTask.Application.UnitOfWorks;
using DevHouseTask.Domain.Entities;
using DevHouseTask.Persistence.Context;
using DevHouseTask.Persistence.Repositories;
using DevHouseTask.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is missing or invalid.");
            }
            services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<Auth>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
