
namespace MXLogbookAPI.Services.VehicleService
{
    public interface IVehicleService
    {   //Task makes a asyncrounous function along with async
        Task<ServiceResponse<List<GetVehicleDto>>> GetAllVehicles();

        Task<ServiceResponse<GetVehicleDto>> GetVehicleById(int vehicleId);

        Task<ServiceResponse<List<GetVehicleDto>>> AddNewVehicle(AddVehicleDto newVehicle);

        Task<ServiceResponse<GetVehicleDto>> UpdateVehicle(UpdateVehicleDto updateVehicle);

        Task<ServiceResponse<List<GetVehicleDto>>> DeleteVehicle(int vehicleId);
    }
}
