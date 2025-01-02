using DevHouseTask.Infrastruckture.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHouseTask.Infrastruckture
{
    public static class Registration
    {
        public static void AddInfrastruckture(this IServiceCollection services,IConfiguration configuration) 
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        }
    }
}
