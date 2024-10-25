using DeliveryServiceWebAPI.Configuration;
using DeliveryServiceWebAPI.Core.Database.Repository;
using DeliveryServiceWebAPI.Core.Database.Repository.Interface;
using DeliveryServiceWebAPI.Core.Database.UnitOfWork;
using DeliveryServiceWebAPI.Core.Services;
using DeliveryServiceWebAPI.Core.Services.Interfaces;
using DeliveryServiceWebAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.DependencyInjection
{
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
