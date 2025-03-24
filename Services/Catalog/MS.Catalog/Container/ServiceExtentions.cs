using MS.Catalog.Services.AboutServices;
using MS.Catalog.Services.BrandServices;
using MS.Catalog.Services.ProductServices;
using MS.Catalog.Services.FeatureServices;
using MS.Catalog.Services.CategoryServices;
using MS.Catalog.Services.ProductImageServices;
using MS.Catalog.Services.SpecialOfferServices;
using MS.Catalog.Services.ProductDetailServices;
using MS.Catalog.Services.FeatureSliderServices;
using MS.Catalog.Services.OfferDiscountServices;

namespace MS.Catalog.Container;

public static class ServiceExtentions
{
    public static void AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IFeatureSliderService, FeatureSliderService>();
        services.AddScoped<ISpecialOfferService, SpecialOfferService>();
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddScoped<IOfferDiscountService, OfferDiscountService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IAboutService, AboutService>();
    }
}
