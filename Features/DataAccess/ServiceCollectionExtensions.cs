﻿using Microsoft.EntityFrameworkCore;
using ShopAPI.Features.DataAccess.Repositories;
using ShopAPI.Features.DataAccess.Repositories.DeliveryRepository;
using ShopAPI.Features.DataAccess.Repositories.NotificationsRepository;
using ShopAPI.Features.DataAccess.Repositories.OrdersRepository;
using ShopAPI.Features.DataAccess.Repositories.PaymentsRepository;
using ShopAPI.Features.DataAccess.Repositories.ProductsRepository;
using ShopAPI.Features.DataAccess.Repositories.UsersRepository;

namespace ShopAPI.Features.DataAccess
{
    /// <summary>
    ///     DataAccess extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds db context
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddShopServiceDbContext(this IServiceCollection services)
        {
            var postgresServer = Environment.GetEnvironmentVariable("PostgresServer");
            var postgresDb = Environment.GetEnvironmentVariable("PostgresDb");
            var postgresUser = Environment.GetEnvironmentVariable("PostgresUser");
            var postgresPassword = Environment.GetEnvironmentVariable("PostgresPassword");
            var postgresPort = Environment.GetEnvironmentVariable("PostgresPort");
            var postgresConnectionString = string.IsNullOrEmpty(postgresServer)
                ? null
                : $"User ID={postgresUser};Password={postgresPassword};Host={postgresServer};Port={postgresPort};Database={postgresDb};Pooling=true;Maximum Pool Size=300;";
            const string defaultConnection =
                "User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=ShopDataBase;Pooling=true;";

            var opts = new DbContextOptionsBuilder<ShopDbContext>();
            opts.UseNpgsql(postgresConnectionString ?? defaultConnection);
            opts.EnableSensitiveDataLogging() /*.UseLoggerFactory(MyLoggerFactory)*/;

            services.AddScoped(f => new ShopDbContext(opts.Options));

            return services;
        }

        /// <summary>
        ///     Add repos and unit of work
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddShopServiceEntityFrameworkRepositories(this IServiceCollection services)
        {
            // Add DI here for repos

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<INotificationsRepository, NotificationsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}