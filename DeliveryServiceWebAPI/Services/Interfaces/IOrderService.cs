using DeliveryServiceWebAPI.DTO;
using DeliveryServiceWebAPI.Entities;

namespace DeliveryServiceWebAPI.Services.Interfaces {
    public interface IOrderService {
        public void CreateOrder(OrderDto orderDto);

        public List<Orders> FilterOrders(string region, DateTime fromTime); 
    }
}
