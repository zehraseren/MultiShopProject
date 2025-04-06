using MS.WebUI.Services.Concrete;
using MS.WebUI.Services.Interfaces;

namespace MS.WebUI.Container;

public static class Extentions
{
    public static void ContainerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILoginService, LoginService>();
    }
}
