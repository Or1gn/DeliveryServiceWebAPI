using DeliveryServiceWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.DatabaseHandler {
    public class DeliveryServiceDbContext : DbContext {
        public DeliveryServiceDbContext(DbContextOptions<DeliveryServiceDbContext> options) : base(options) { }

        public virtual DbSet<Orders> Orders { get; set; }   
        public virtual DbSet<Logs> Logs { get; set; }   
        public virtual DbSet<FilteredOrders> FilteredOrders { get; set; } 
    }
}
