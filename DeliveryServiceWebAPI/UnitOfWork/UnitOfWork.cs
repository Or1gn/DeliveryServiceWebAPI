using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceWebAPI.UnitOfWork {
    public interface IUnitOfWork : IDisposable {
        void SaveChanges();
    }
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext {
        private readonly T context;
        public UnitOfWork(T context) { 
            this.context = context;
        }
        public void Dispose() {
            context.Dispose();
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
