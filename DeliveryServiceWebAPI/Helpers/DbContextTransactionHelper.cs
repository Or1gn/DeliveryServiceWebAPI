using DeliveryServiceWebAPI.DatabaseHandler;
using DeliveryServiceWebAPI.Services.Interfaces;
using System.Diagnostics;

namespace DeliveryServiceWebAPI.Helpers {
    public class DbContextTransactionHelper {
        private readonly DeliveryServiceDbContext context;
        private readonly ILogService logService;

        public DbContextTransactionHelper(DeliveryServiceDbContext context, ILogService logService) { 
            this.context = context;
            this.logService = logService;
        }

        public void CallTransaction(Action action) {
            using (var transaction = context.Database.BeginTransaction()) {
                try {
                    action();
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception) {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public T CallTransaction<T>(Func<T> func) {
            using (var transaction = context.Database.BeginTransaction()) {
                try {
                    T result = func();
                    context.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception) {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
