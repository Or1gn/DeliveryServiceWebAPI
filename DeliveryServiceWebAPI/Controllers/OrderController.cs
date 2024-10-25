using DeliveryServiceWebAPI.Core.Data.DTO;
using DeliveryServiceWebAPI.Core.Data.Entities.Request;
using DeliveryServiceWebAPI.Core.Services.Interfaces;
using DeliveryServiceWebAPI.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        private readonly IOrderService orderService;
        private readonly IFilteredOrderService filteredOrderService;
        private readonly IValidateService validateService;

        public OrderController(IOrderService orderService, 
                                IFilteredOrderService filteredOrderService,
                                IValidateService validateService) { 
            this.orderService = orderService;
            this.filteredOrderService = filteredOrderService;
            this.validateService = validateService;
        }

        [HttpGet("api/get_filtered_orders_from_configuration_data")]
        public IActionResult GetFilteredOrdersFromConfigurationData() {
            var request = filteredOrderService.GetFilterOrderRequestFromConfiguration();

            if (request == null) 
                return Ok("Не удалось получить информацию из файла конфигурации! Для большей информации см. таблицу logs");

            return FilterOrders(request);
        }

        [HttpGet("api/get_filtered_orders")]
        public IActionResult GetFilteredOrders([FromQuery] FilterOrderRequest request) {
            return FilterOrders(request);
        }

        [HttpPut("api/add_orders")]
        public IActionResult AddOrder(OrderDto orderDto) { 
            orderService.CreateOrder(orderDto);
            return Ok("Success");
        }

        private IActionResult FilterOrders(FilterOrderRequest request) {
            if (!validateService.ValidateRequest(request)) return Ok("Данные не прошли проверку!");

            var orders = orderService.FilterOrders(request.cityDistrict, request.firstDeliveryDateTime.Value);

            if (orders == null) return Ok("Ошибка при получении заказов!");
            if (orders.Count == 0) return Ok("Заказы в данном регионе и данной датой не найдены!");

            filteredOrderService.ClearFilteredData();
            filteredOrderService.AddFilterData(orders);
            return Ok(orders);
        }

    }
}
