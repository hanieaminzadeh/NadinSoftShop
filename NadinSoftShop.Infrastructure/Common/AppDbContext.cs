using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NadinSoftShop.Domain.Product.Entities;
using NadinSoftShop.Infrastructure.Configurations;

namespace NadinSoftShop.Infrastructure.Common
{
    public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductEntityConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }

    }

}