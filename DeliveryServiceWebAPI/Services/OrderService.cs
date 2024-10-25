using DeliveryServiceWebAPI.DTO;
using DeliveryServiceWebAPI.Entities;
using DeliveryServiceWebAPI.Helpers;
using DeliveryServiceWebAPI.Repository.Interface;
using DeliveryServiceWebAPI.Services.Interfaces;
using DeliveryServiceWebAPI.UnitOfWork;

namespace DeliveryServiceWebAPI.Services {
    public class OrderService : IOrderService {
        private readonly IOrderRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogService logService;
        private readonly DbContextTransactionHelper dbContextTransactionHelper;

        public OrderService(IOrderRepository repository, 
                            IUnitOfWork unitOfWork, 
                            ILogService logService, 
                            DbContextTransactionHelper dbContextTransactionHelper) { 
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.logService = logService;
            this.dbContextTransactionHelper = dbContextTransactionHelper;
        }

        public void CreateOrder(OrderDto orderDto) {
            try {
                dbContextTransactionHelper.CallTransaction(() => {
                    Orders order = orderDto.AsOrder();

                    repository.Add(order);

                    unitOfWork.SaveChanges();
                });
            }
            catch (Exception ex) {
                logService.WriteError("CreateOrder", ex.Message);
                unitOfWork.SaveChanges();
            }
        }

        public List<Orders> FilterOrders(string region, DateTime fromTime) {
            try {
                List<Orders> orders = repository.GetAll();

                return orders.Where(o => o.Region.ToUpper().Equals(region.ToUpper())
                                    && o.DeliveryTime <= fromTime.AddMinutes(30).ToUniversalTime()).ToList();
            }
            catch (Exception ex) {
                logService.WriteError("FilterOrders", ex.Message);
                unitOfWork.SaveChanges();
                return null;
            }
        }
    }
}
