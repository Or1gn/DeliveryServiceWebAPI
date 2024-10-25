using DeliveryServiceWebAPI.Core.Data.Entities;
using DeliveryServiceWebAPI.Core.Database;
using DeliveryServiceWebAPI.Core.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.Core.Database.Repository
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        private readonly DbSet<Orders> dbSet;

        public OrderRepository(DeliveryServiceDbContext context) : base(context)
        {
        }
    }
}
