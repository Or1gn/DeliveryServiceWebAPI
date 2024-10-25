using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceWebAPI.Core.Data.Entities
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [Column("serial_number")]
        public Guid SerialNumber { get; set; }
        [Column("weight")]
        public decimal Weight { get; set; }
        [Column("region")]
        public string Region { get; set; }
        [Column("delivery_time")]
        public DateTime DeliveryTime { get; set; }
    }
}
