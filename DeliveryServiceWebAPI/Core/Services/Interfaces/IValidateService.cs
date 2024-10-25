using DeliveryServiceWebAPI.Core.Data.Entities.Request;

namespace DeliveryServiceWebAPI.Core.Services.Interfaces
{
    public interface IValidateService
    {
        bool ValidateRequest(FilterOrderRequest filterOrderRequest);
    }
}
