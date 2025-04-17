using MS.WebUI.Handlers;
using MS.WebUI.Settings;
using MS.WebUI.Services.Concrete;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.BasketServices;
using MS.WebUI.Services.CommentServices;
using MS.WebUI.Services.CatalogServices.BrandServices;
using MS.WebUI.Services.CatalogServices.AboutServices;
using MS.WebUI.Services.CatalogServices.ProductServices;
using MS.WebUI.Services.CatalogServices.FeatureServices;
using MS.WebUI.Services.CatalogServices.ContactServices;
using MS.WebUI.Services.CatalogServices.CategoryServices;
using MS.WebUI.Services.CatalogServices.SpecialOfferServices;
using MS.WebUI.Services.CatalogServices.FeatureSliderServices;
using MS.WebUI.Services.CatalogServices.OfferDiscountServices;
using MS.WebUI.Services.CatalogServices.ProductImageServices;
using MS.WebUI.Services.CatalogServices.ProductDetailServices;

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

        services.AddHttpClient<IProductService, ProductService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IFeatureService, FeatureService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IBrandService, BrandService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IAboutService, AboutService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ICommentService, CommentService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Comment.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IContactService, ContactService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Catalog.Path}/");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IBasketService, BasketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{value.OcelotUrl}/{value.Basket.Path}/");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
    }
}
