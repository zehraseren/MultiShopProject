using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MS.Order.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
