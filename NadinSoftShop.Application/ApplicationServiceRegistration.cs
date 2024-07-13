using Microsoft.Extensions.DependencyInjection;
using NadinSoftShop.Application.Contracts.Prodcut;
using NadinSoftShop.Application.Contracts.User;
using NadinSoftShop.Application.Features.Product.Commnads;
using NadinSoftShop.Application.Features.Product.Queries;
using NadinSoftShop.Application.Features.User.Commands;
using NadinSoftShop.Application.Features.User.Queries;


namespace NadinSoftShop.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllProductQueryHandler, GetAllProductQueryHandler>();
            services.AddScoped<IGetProductQueryHandler, GetProductQueryHandler>();
            services.AddScoped<IDeleteProductCommandHandler, DeleteProductCommandHandler>();
            services.AddScoped<IRegisterUserCommandHandler, RegisterUserCommandHandler>();
            services.AddScoped<ILoginUserQueryHandler, LoginUserQueryHandler>();
            services.AddScoped<ICreateProductCommandHandler, CreateProductCommandHandler>();
            services.AddScoped<IUpdateProductCommandHandler, UpdateProductCommandHandler>();

            return services;
        }
    }
}
