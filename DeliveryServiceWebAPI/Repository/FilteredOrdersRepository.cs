using DeliveryServiceWebAPI.DatabaseHandler;
using DeliveryServiceWebAPI.Entities;
using DeliveryServiceWebAPI.Repository.Interface;

namespace DeliveryServiceWebAPI.Repository {
    public class FilteredOrdersRepository : Repository<FilteredOrders>, IFilteredOrdersRepository {
        public FilteredOrdersRepository(DeliveryServiceDbContext dbContext) : base(dbContext) {
        }

        public void Clear() {
            var filteredOrders = dbSet.ToList();
            dbSet.RemoveRange(filteredOrders);
        }
    }
}
