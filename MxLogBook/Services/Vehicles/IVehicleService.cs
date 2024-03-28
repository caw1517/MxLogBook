using Backend.Models;

namespace Backend.Services
{
    public interface IVehicleService : IGenericService<Vehicle>
    {
        Task<Vehicle?> GetDetails(int id);
        Task<List<Vehicle>> GetVehiclesByUserId(string userId);
        Task<List<Vehicle>> GetVehiclesByCompanyId(int companyId);
        Task<bool> VerifyVehicleOwner(string userId, int vehicleId);
    }
}
