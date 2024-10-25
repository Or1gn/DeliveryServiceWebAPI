using DeliveryServiceWebAPI.DatabaseHandler;
using DeliveryServiceWebAPI.Entities;
using DeliveryServiceWebAPI.Repository.Interface;

namespace DeliveryServiceWebAPI.Repository {
    public class LogRepository : Repository<Logs>, ILogRepository {
        public LogRepository(DeliveryServiceDbContext dbContext) : base(dbContext) {
        }
    }
}
