using DeliveryServiceWebAPI.DatabaseHandler;
using DeliveryServiceWebAPI.Entities;
using DeliveryServiceWebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.Repository {
    public class OrderRepository : Repository<Orders>, IOrderRepository   {
        private readonly DbSet<Orders> dbSet;

        public OrderRepository(DeliveryServiceDbContext context) : base(context) {
        }
    }
}
