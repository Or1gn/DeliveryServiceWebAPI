using DeliveryServiceWebAPI.Core.Data.DTO;
using DeliveryServiceWebAPI.Core.Data.Entities;

namespace DeliveryServiceWebAPI.Helpers
{
    public static class DtoConverter {
        public static Orders AsOrder(this OrderDto orderDto) {
            return new Orders {
                SerialNumber = Guid.NewGuid(),
                Weight = orderDto.Weight,
                Region = orderDto.Region,
                DeliveryTime = DateTime.UtcNow
            };
        }

        public static FilteredOrders AsFilteredOrdere(this Orders orders, DateTime filteredAt) {
            return new FilteredOrders { 
                Id = Guid.NewGuid(),
                SerialNumber = orders.SerialNumber,
                Weight = orders.Weight, 
                Region = orders.Region,
                DeliveryTime = orders.DeliveryTime,
                FilteredAt = filteredAt
            };
        }
    }
}
