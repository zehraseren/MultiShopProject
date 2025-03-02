using MS.Catalog.Services.ProductServices;
using MS.Catalog.Services.CategoryServices;
using MS.Catalog.Services.ProductImageServices;
using MS.Catalog.Services.ProductDetailServices;

namespace MS.Catalog.Container
{
    public static class ServiceExtentions
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
        }
    }
}
