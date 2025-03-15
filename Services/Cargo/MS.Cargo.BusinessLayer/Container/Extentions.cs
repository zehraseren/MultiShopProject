using MS.Cargo.BusinessLayer.Abstract;
using MS.Cargo.BusinessLayer.Concrete;
using MS.Cargo.DataAccessLayer.Abstract;
using MS.Cargo.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace MS.Cargo.BusinessLayer.Container;

public static class Extentions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
        services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();

        services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
        services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();

        services.AddScoped<ICargoDetailService, CargoDetailManager>();
        services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();

        services.AddScoped<ICargoOperationService, CargoOperationManager>();
        services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
    }
}
