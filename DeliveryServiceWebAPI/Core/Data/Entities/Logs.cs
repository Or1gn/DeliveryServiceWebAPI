using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceWebAPI.Core.Data.Entities
{
    [Table("logs")]
    public class Logs
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("method_name")]
        public string MethodName { get; set; }
        [Column("result")]
        public string Result { get; set; }
        [Column("log_type")]
        public string LogType { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
