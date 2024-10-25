namespace DeliveryServiceWebAPI.Core.Data.Entities.Request
{
    public class FilterOrderRequest
    {
        public string cityDistrict { get; set; }
        public DateTime? firstDeliveryDateTime { get; set; }
    }
}
