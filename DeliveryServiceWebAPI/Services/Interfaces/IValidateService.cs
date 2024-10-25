using DeliveryServiceWebAPI.Entities.Request;

namespace DeliveryServiceWebAPI.Services.Interfaces {
    public interface IValidateService {
        bool ValidateRequest(FilterOrderRequest filterOrderRequest);
    }
}
