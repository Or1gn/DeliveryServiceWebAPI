namespace DeliveryServiceWebAPI.Core.Services.Interfaces
{
    public interface ILogService
    {
        void WriteError(string methodName, string result);
        void WriteInfo(string methodName, string result);
    }
}
