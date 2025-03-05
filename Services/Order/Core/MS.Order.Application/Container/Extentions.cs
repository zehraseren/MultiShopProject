using Microsoft.Extensions.DependencyInjection;
using MS.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MS.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

namespace MS.Order.Application.Container
{
    public static class Extentions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();

            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
        }
    }
}
