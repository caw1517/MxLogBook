using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class LogItemService : GenericService<LogItem>, ILogItemService
    {
        private readonly MxLogBookDbContext _dbContext;
        public LogItemService(MxLogBookDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<LogItem>> GetAllByVehicleId(int vehicleId)
        {
            var logs = await _dbContext.LogItems.Include(q => q.User).Where(v => v.VehicleId == vehicleId).ToListAsync();

            if (logs == null)
                return null;

            return logs;
        }

        public async Task<LogItem> GetLogItemAsyncById(int id)
        {
            //Will return null if value can not be found
            var res = await _dbContext.LogItems.Include(q => q.User).FirstOrDefaultAsync(q => q.Id == id);

            return res!;
        }

        public async Task SetLogItemStatus(int logId, bool status)
        {
            //Get the log item
            var logItem = await GetLogItemAsyncById(logId);

            //Set the values
            logItem.Closed = status;
            logItem.ClosedOn = DateTime.UtcNow;

            _dbContext.Update(logItem);

            await _dbContext.SaveChangesAsync();
        }
    }
}
