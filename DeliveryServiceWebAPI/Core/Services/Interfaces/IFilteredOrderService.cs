using DeliveryServiceWebAPI.Core.Data.Entities;
using DeliveryServiceWebAPI.Core.Data.Entities.Request;

namespace DeliveryServiceWebAPI.Core.Services.Interfaces
{
    public interface IFilteredOrderService
    {
        void ClearFilteredData();
        void AddFilterData(List<Orders> orders);
        FilterOrderRequest? GetFilterOrderRequestFromConfiguration();
    }
}
