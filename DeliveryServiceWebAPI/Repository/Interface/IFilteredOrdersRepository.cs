using DeliveryServiceWebAPI.Entities;

namespace DeliveryServiceWebAPI.Repository.Interface {
    public interface IFilteredOrdersRepository : IRepository<FilteredOrders> {
        void Clear();
    }
}
