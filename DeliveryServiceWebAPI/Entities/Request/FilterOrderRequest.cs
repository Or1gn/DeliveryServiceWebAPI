namespace DeliveryServiceWebAPI.Entities.Request {
    public class FilterOrderRequest {
        public string cityDistrict { get; set; }
        public DateTime? firstDeliveryDateTime { get; set; }
    }
}
