﻿using CleanArchitecture.Domain.Common.Interfaces;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            return services;
        }
    }
}