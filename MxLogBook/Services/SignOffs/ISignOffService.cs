using Backend.Models;
using Backend.DTOs.SignOff;

namespace Backend.Services.SignOffs
{
    public interface ISignOffService : IGenericService<SignOff>
    {
        Task<List<SignOff>> GetSignOffFromLog(int logId);
        //Task<Liset<SignOff>> GetSignOffFromTask(int taskId);
    }
}
