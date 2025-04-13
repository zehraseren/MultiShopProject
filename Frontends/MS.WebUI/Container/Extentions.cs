using MS.WebUI.Handlers;
using MS.WebUI.Settings;
using MS.WebUI.Services.Concrete;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.CatalogServices.CategoryServices;

namespace MS.WebUI.Container;

public static class Extentions
{
    public static void ContainerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Services & Handlers
        services.AddScoped<ILoginService, LoginService>();
        services.AddHttpClient<IIdentityService, IdentityService>();
        services.AddScoped<ResourceOwnerPasswordTokenHandler>();
        services.AddScoped<ClientCredentialTokenHandler>();
        services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

        // Add Settings Configurations
        services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
        services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

        // HttpClient Configurations
        var value = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        services.AddHttpClient<IUserService, UserService>(opt =>
        {
            opt.BaseAddress = new Uri(value.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICategoryService, CategoryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
    }
}
