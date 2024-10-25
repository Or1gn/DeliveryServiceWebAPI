using DeliveryServiceWebAPI.Repository.Interface;
using DeliveryServiceWebAPI.Services.Interfaces;
using DeliveryServiceWebAPI.UnitOfWork;

namespace DeliveryServiceWebAPI.Services {
    public class LogService : ILogService {
        private readonly ILogRepository logRepository;
        private readonly IUnitOfWork unitOfWork;
        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork) { 
            this.logRepository = logRepository;
            this.unitOfWork = unitOfWork;
        }
        public void WriteError(string methodName, string result) {
            logRepository.Add(new Entities.Logs { 
                Id = Guid.NewGuid(),
                MethodName = methodName,
                Result = result,
                LogType = "Error",
                CreatedDate = DateTime.UtcNow
            });

            unitOfWork.SaveChanges();
        }

        public void WriteInfo(string methodName, string result) {   
            logRepository.Add(new Entities.Logs {
                Id = Guid.NewGuid(),
                MethodName = methodName,
                Result = result,
                LogType = "Info",
                CreatedDate = DateTime.UtcNow
            });

            unitOfWork.SaveChanges();
        }
    }
}
