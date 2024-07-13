using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NadinSoftShop.Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;
using NadinSoftShop.Infrastructure.Repositories;
using NadinSoftShop.Application.Contracts.Prodcut;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace NadinSoftShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepositoryDapper, ProductRepositoryDapper>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           
            


                return services;
        }
    }
}
