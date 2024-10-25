using DeliveryServiceWebAPI.Core.Data.DTO;
using DeliveryServiceWebAPI.Core.Data.Entities;

namespace DeliveryServiceWebAPI.Core.Services.Interfaces
{
    public interface IOrderService
    {
        public void CreateOrder(OrderDto orderDto);

        public List<Orders> FilterOrders(string region, DateTime fromTime);
    }
}
