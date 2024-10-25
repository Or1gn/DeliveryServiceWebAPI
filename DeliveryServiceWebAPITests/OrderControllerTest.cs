using DeliveryServiceWebAPI.Controllers;
using DeliveryServiceWebAPI.Core.Data.Entities.Request;
using DeliveryServiceWebAPI.Core.Services.Interfaces;
using DeliveryServiceWebAPI.Core.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Legacy;

namespace DeliveryServiceWebAPITests
{
    public class Tests {
        [TestFixture]
        public class OrderControllerTests {
            private Mock<IOrderService> _orderServiceMock;
            private Mock<IFilteredOrderService> _filteredOrderServiceMock;
            private Mock<IValidateService> _validateServiceMock;
            private OrderController _controller;

            [SetUp]
            public void Setup() {
                _orderServiceMock = new Mock<IOrderService>();
                _filteredOrderServiceMock = new Mock<IFilteredOrderService>();
                _validateServiceMock = new Mock<IValidateService>();
                _controller = new OrderController(_orderServiceMock.Object, _filteredOrderServiceMock.Object, _validateServiceMock.Object);
            }

            [Test]
            public void GetFilteredOrders_ReturnsBadRequest_WhenRequestIsInvalid() {
                var request = new FilterOrderRequest { cityDistrict = "Воронеж", firstDeliveryDateTime = DateTime.UtcNow };
                _validateServiceMock.Setup(s => s.ValidateRequest(request)).Returns(false);

                var result = _controller.GetFilteredOrders(request);

                var okResult = result as OkObjectResult;
                ClassicAssert.IsNotNull(okResult);
                ClassicAssert.AreEqual("Данные не прошли проверку!", okResult.Value);
            }

            [Test]
            public void AddOrder_ReturnsOk_WhenOrderIsCreated() {
                var orderDto = new OrderDto { 
                    Weight = 20.5M,
                    Region = "Воронеж"
                };

                var result = _controller.AddOrder(orderDto);

                var okResult = result as OkObjectResult;
                ClassicAssert.IsNotNull(okResult);
                ClassicAssert.AreEqual("Success", okResult.Value);
            }

            [Test]
            public void GetFilteredOrdersFromConfigurationData_ReturnsError_WhenRequestIsNull() {
                _filteredOrderServiceMock.Setup(s => s.GetFilterOrderRequestFromConfiguration()).Returns((FilterOrderRequest)null);

                var result = _controller.GetFilteredOrdersFromConfigurationData();

                var okResult = result as OkObjectResult;
                ClassicAssert.IsNotNull(okResult);
                ClassicAssert.AreEqual("Не удалось получить информацию из файла конфигурации! Для большей информации см. таблицу logs", okResult.Value);
            }
        }
    }
}