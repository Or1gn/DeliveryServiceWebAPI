using DeliveryServiceWebAPI.Configuration;
using DeliveryServiceWebAPI.Core.Data.Entities;
using DeliveryServiceWebAPI.Core.Data.Entities.Request;
using DeliveryServiceWebAPI.Core.Database.Repository.Interface;
using DeliveryServiceWebAPI.Core.Database.UnitOfWork;
using DeliveryServiceWebAPI.Core.Services.Interfaces;
using DeliveryServiceWebAPI.Helpers;
using Microsoft.Extensions.Options;

namespace DeliveryServiceWebAPI.Core.Services
{
    public class FilteredOrderService : IFilteredOrderService
    {
        private readonly IFilteredOrdersRepository filteredOrdersRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogService logService;
        private readonly DbContextTransactionHelper dbContextTransactionHelper;
        private readonly ControllerSettings controllerSettings;
        public FilteredOrderService(IFilteredOrdersRepository filteredOrdersRepository,
                                    IUnitOfWork unitOfWork,
                                    ILogService logService,
                                    DbContextTransactionHelper dbContextTransactionHelper,
                                    IOptions<ControllerSettings> controllerSettings)
        {
            this.filteredOrdersRepository = filteredOrdersRepository;
            this.unitOfWork = unitOfWork;
            this.logService = logService;
            this.dbContextTransactionHelper = dbContextTransactionHelper;
            this.controllerSettings = controllerSettings.Value;
        }
        public void AddFilterData(List<Orders> orders)
        {
            try
            {
                dbContextTransactionHelper.CallTransaction(() =>
                {
                    var filteredOrders = orders.Select(x => x.AsFilteredOrdere(DateTime.UtcNow)).ToList();
                    filteredOrdersRepository.AddRange(filteredOrders);
                    logService.WriteInfo("AddFilterData", "Добавлены отфильтрованные данные!");
                });
            }
            catch (Exception ex)
            {
                logService.WriteError("AddFilterData", ex.Message);
                unitOfWork.SaveChanges();
            }
        }

        public void ClearFilteredData()
        {
            try
            {
                dbContextTransactionHelper.CallTransaction(filteredOrdersRepository.Clear);
            }
            catch (Exception ex)
            {
                logService.WriteError("ClearFilteredData", ex.Message);
                unitOfWork.SaveChanges();
            }
        }

        public FilterOrderRequest? GetFilterOrderRequestFromConfiguration()
        {
            try
            {
                return new FilterOrderRequest()
                {
                    cityDistrict = controllerSettings.CityDistrict,
                    firstDeliveryDateTime = controllerSettings.FirstDeliveryDateTime
                };
            }
            catch (Exception ex)
            {
                logService.WriteError("GetFilterOrderRequestFromConfiguration", ex.Message);
                return null;
            }

        }
    }
}
