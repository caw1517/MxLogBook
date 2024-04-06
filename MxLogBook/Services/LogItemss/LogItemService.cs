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
            var logs = await _dbContext.LogItems
                .Include(q => q.User)
                .ThenInclude(so => so!.SignOffs)
                .Where(v => v.VehicleId == vehicleId).ToListAsync();

            if (logs.Count == 0)
                throw new InvalidOperationException("No logs assigned to that vehicle.");

            return logs;
        }

        public async Task<List<LogItem>> GetLogsByUserId(string userId)
        {
            var logs = await _dbContext.LogItems
                .Include(q => q.User)
                .ThenInclude(so => so!.SignOffs)
                .Where(u => u.UserId == userId).ToListAsync();

            if (logs.Count == 0)
                throw new InvalidOperationException("This user currently has no logs");

            return logs;
        }

        public async Task<LogItem> GetLogItemAsyncById(int id)
        {
            var res = await _dbContext.LogItems.Include(q => q.User).FirstOrDefaultAsync(q => q.Id == id);

            if (res == null)
                throw new InvalidOperationException("Not Found");
            
            return res;
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
