using DeliveryServiceWebAPI.Configuration;
using DeliveryServiceWebAPI.Helpers;
using DeliveryServiceWebAPI.Repository;
using DeliveryServiceWebAPI.Repository.Interface;
using DeliveryServiceWebAPI.Services;
using DeliveryServiceWebAPI.Services.Interfaces;
using DeliveryServiceWebAPI.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.DependencyInjection {
    public static class DependencyInjection {
        public static void AddRepositories<T>(this IServiceCollection services) where T : DbContext {
            services.AddScoped<IUnitOfWork, UnitOfWork<T>>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IFilteredOrdersRepository, FilteredOrdersRepository>();
        }

        public static void AddServices(this IServiceCollection services) {
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFilteredOrderService, FilteredOrderService>();
            services.AddScoped<IValidateService, ValidateService>();
        }

        public static void AddHelpers(this IServiceCollection services) {
            services.AddScoped<DbContextTransactionHelper>();
        }

        public static void AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration) {
            services.Configure<ControllerSettings>(configuration.GetSection("ControllerSettings"));
        }
    }
}
