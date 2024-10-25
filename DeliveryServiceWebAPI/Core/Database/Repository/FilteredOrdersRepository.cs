using DeliveryServiceWebAPI.Core.Data.Entities;
using DeliveryServiceWebAPI.Core.Database;
using DeliveryServiceWebAPI.Core.Database.Repository.Interface;

namespace DeliveryServiceWebAPI.Core.Database.Repository
{
    public class FilteredOrdersRepository : Repository<FilteredOrders>, IFilteredOrdersRepository
    {
        public FilteredOrdersRepository(DeliveryServiceDbContext dbContext) : base(dbContext)
        {
        }

        public void Clear()
        {
            var filteredOrders = dbSet.ToList();
            dbSet.RemoveRange(filteredOrders);
        }
    }
}
