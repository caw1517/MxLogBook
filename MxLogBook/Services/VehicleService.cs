using Backend.Services;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class VehicleService : GenericService<Vehicle>, IVehicleService
    {
        private readonly MxLogBookDbContext _dbContext;
        public VehicleService(MxLogBookDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Vehicle> GetDetails(int id)
        {
            //Will return null if value can not be found
            return await _dbContext.vehicles.Include(q => q.LogItems).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
