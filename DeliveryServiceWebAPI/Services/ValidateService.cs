using DeliveryServiceWebAPI.Entities.Request;
using DeliveryServiceWebAPI.Services.Interfaces;

namespace DeliveryServiceWebAPI.Services {
    public class ValidateService : IValidateService {
        private readonly ILogService logService;
        public ValidateService(ILogService logService) { 
            this.logService = logService;
        }
        public bool ValidateRequest(FilterOrderRequest filterOrderRequest) {
            if (filterOrderRequest == null) {
                logService.WriteError("ValidateRequest", "Нет передаваемых данных!");
                return false;
            }

            if (filterOrderRequest.cityDistrict.Trim().Equals(string.Empty)) {
                logService.WriteError("ValidateRequest", "Нет данных о городе!");
                return false;
            }

            if (filterOrderRequest.firstDeliveryDateTime == null) {
                logService.WriteError("ValidateRequest", "Нет данных о дате первого заказа!");
                return false;
            }

            logService.WriteInfo("ValidateRequest", "Данные успешно прошли проверку!");
            return true;
        }
    }
}
