using DeliveryServiceWebAPI.Entities;
using DeliveryServiceWebAPI.Entities.Request;

namespace DeliveryServiceWebAPI.Services.Interfaces {
    public interface IFilteredOrderService {
        void ClearFilteredData();
        void AddFilterData(List<Orders> orders);
        FilterOrderRequest? GetFilterOrderRequestFromConfiguration();
    }
}
