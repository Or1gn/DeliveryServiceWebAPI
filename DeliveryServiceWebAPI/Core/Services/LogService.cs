using DeliveryServiceWebAPI.Core.Database.Repository.Interface;
using DeliveryServiceWebAPI.Core.Database.UnitOfWork;
using DeliveryServiceWebAPI.Core.Services.Interfaces;

namespace DeliveryServiceWebAPI.Core.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;
        private readonly IUnitOfWork unitOfWork;
        public LogService(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            this.logRepository = logRepository;
            this.unitOfWork = unitOfWork;
        }
        public void WriteError(string methodName, string result)
        {
            logRepository.Add(new Core.Data.Entities.Logs
            {
                Id = Guid.NewGuid(),
                MethodName = methodName,
                Result = result,
                LogType = "Error",
                CreatedDate = DateTime.UtcNow
            });

            unitOfWork.SaveChanges();
        }

        public void WriteInfo(string methodName, string result)
        {
            logRepository.Add(new Core.Data.Entities.Logs
            {
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
