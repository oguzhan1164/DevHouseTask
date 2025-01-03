using DevHouseTask.Application.Bases;
using DevHouseTask.Application.Beheviors;
using DevHouseTask.Application.Exceptions;
using DevHouseTask.Application.Features.Pages.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;


namespace DevHouseTask.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            services.AddRulesForAssemblyContaining(assembly,typeof(BaseRules));

        }
        private static IServiceCollection AddRulesForAssemblyContaining(this IServiceCollection services,Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type !=t).ToList();
            foreach (var item in types)
                services.AddTransient(item);
            return services;
        }
    }
}
