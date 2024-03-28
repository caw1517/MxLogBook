using AutoMapper;
using Backend.DTOs.LogItem;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogItemService _logService;
        private readonly IVehicleService _vehicleService;

        public LogItemController(IMapper mapper, ILogItemService logService, IVehicleService vehicleService)
        {
            _mapper = mapper;
            _logService = logService;
            _vehicleService = vehicleService;
        }

        [HttpGet("{logId}")]
        public async Task<ActionResult<GetLogItemDto>> GetLogItemById(int logId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;
            
            var log = await _logService.GetLogItemAsyncById(logId);

            var result = _mapper.Map<GetLogItemDto>(log);
            if (result == null)
                return NotFound(new { message = "Log Item Not Found." });
            
            if (result.VehicleId == 0)
                return BadRequest(new { message = "Vehicle does not have that log item." });

            if (await _vehicleService.VerifyVehicleOwner(userIdClaim, result.VehicleId) == false)
                return BadRequest(new {message = "Invalid vehicle owner"});

            return Ok(result);

        }

        [HttpGet("logs/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<GetLogItemDto>>> GetLogItemByVehicle(int vehicleId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            if (await _vehicleService.VerifyVehicleOwner(userIdClaim, vehicleId) == false)
                return BadRequest(new { message = "Invalid vehicle owner." });
            
            var logs = await _logService.GetAllByVehicleId(vehicleId);
            var records = _mapper.Map<List<GetLogItemDto>>(logs);

            return Ok(records);
        }

        [HttpPost]
        public async Task<ActionResult<CreateLogItemDto>> CreateLogItem(CreateLogItemDto newLogItem)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity!.FindFirst("uid")!.Value;

            if (await _vehicleService.VerifyVehicleOwner(userIdClaim, newLogItem.VehicleId) == false)
                return BadRequest(new { message = "Invalid vehicle owner" });
            
            newLogItem.UserId = userIdClaim;
            
            var logItem = _mapper.Map<LogItem>(newLogItem);
            
            await _logService.AddAsync(logItem);

            return Ok(new {message = "Log Item Created"});
        }

        [HttpDelete("{logId:int}")]
        public async Task<IActionResult> DeleteLogItem(int logId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity!.FindFirst("uid")!.Value;
            
            var logItem = await _logService.GetAsync(logId);

            if (await _vehicleService.VerifyVehicleOwner(userId, logItem.VehicleId) == false)
                return BadRequest(new { message = "Invalid vehicle owner" });

            await _logService.DeleteAsync(logId);

            return Ok(new {message = "Vehicle Deleted."});
        }
    }
}
