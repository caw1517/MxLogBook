using Backend.Models;

namespace Backend.Services
{
    public interface ILogItemService : IGenericService<LogItem>
    {

        Task<LogItem> GetLogItemAsyncById(int id);
        Task<List<LogItem>> GetAllByVehicleId(int vehicleId);
        Task SetLogItemStatus(int logId, bool status);
    }
}
