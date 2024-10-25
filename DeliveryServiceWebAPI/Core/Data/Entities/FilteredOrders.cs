using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceWebAPI.Core.Data.Entities
{
    [Table("filtered_orders")]
    public class FilteredOrders
    {
        public Guid Id { get; set; }
        public Guid SerialNumber { get; set; }
        [Column("weight")]
        public decimal Weight { get; set; }
        [Column("region")]
        public string Region { get; set; }
        [Column("delivery_time")]
        public DateTime DeliveryTime { get; set; }
        [Column("filtered_at")]
        public DateTime FilteredAt { get; set; }
    }
}
