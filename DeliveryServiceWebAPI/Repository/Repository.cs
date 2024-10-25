using DeliveryServiceWebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.Repository {
    public class Repository<T> : IRepository<T> where T : class {
        protected readonly DbSet<T> dbSet;
        public Repository(DbContext dbContext) { 
            dbSet = dbContext.Set<T>();
        }
        public void Add(T entity) {
            dbSet.Add(entity);
        }

        public void AddRange(List<T> entities) {
            dbSet.AddRange(entities);
        }

        public void Delete(T entity) {
            dbSet.Remove(entity);
        }

        public List<T> GetAll() {
            return dbSet.ToList();
        }

        public T GetById(Guid id) {
            return dbSet.Find(id);
        }

        public void Update(T entity) {
            dbSet.Update(entity);
        }
    }
}
