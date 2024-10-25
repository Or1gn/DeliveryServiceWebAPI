using DeliveryServiceWebAPI.Core.Data.Entities;

namespace DeliveryServiceWebAPI.Core.Database.Repository.Interface
{
    public interface IFilteredOrdersRepository : IRepository<FilteredOrders>
    {
        void Clear();
    }
}
