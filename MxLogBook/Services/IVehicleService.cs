using Backend.Models;

namespace Backend.Services
{
    public interface IVehicleService : IGenericService<Vehicle>
    {
        Task<Vehicle> GetDetails(int id);
    }
}
