using DeliveryServiceWebAPI.Core.Data.Entities;
using DeliveryServiceWebAPI.Core.Database;
using DeliveryServiceWebAPI.Core.Database.Repository.Interface;

namespace DeliveryServiceWebAPI.Core.Database.Repository
{
    public class LogRepository : Repository<Logs>, ILogRepository
    {
        public LogRepository(DeliveryServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
