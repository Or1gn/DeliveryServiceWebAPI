namespace DeliveryServiceWebAPI.Core.Database.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        List<T> GetAll();
        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
