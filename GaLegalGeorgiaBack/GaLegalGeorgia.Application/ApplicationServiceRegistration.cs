using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GaLegalGeorgia.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(o => o.RegisterServicesFromAssemblies(thisAssembly));

            return services;
        }
    }
}
