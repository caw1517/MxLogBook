using AutoMapper;
using Backend.DTOs.LogItem;
using Backend.DTOs.Vehicles;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogItemService _logService;

        public LogItemController(IMapper mapper, ILogItemService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        //GET: All Log Items - Shouldn't be used, only to be used by admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllLogsDto>>> GetLogItems()
        {
            var logs = await _logService.GetAllAsync();
            var records = _mapper.Map<List<GetAllLogsDto>>(logs);
            return Ok(records);
        }

        //GET: Single Log Item - Used in the context of opening a single log item
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLogItemDto>> GetLogItemById(int id)
        {
            var log = await _logService.GetLogItemAsyncById(id);

            if (log == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetLogItemDto>(log);

            return Ok(result);

        }

        //GET: Multiple Items Associated with Specific Vehicle - Used by people that own vehicle / have access via company
        [HttpGet("logs/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<GetLogItemDto>>> GetLogItemByVehicle(int vehicleId)
        {
            var logs = await _logService.GetAllByVehicleId(vehicleId);
            var records = _mapper.Map<List<GetLogItemDto>>(logs);

            return Ok(records);
        }

        //POST - Create a new log, can be used by anyone authorized.
        [HttpPost]
        public async Task<ActionResult<CreateLogItemDto>> CreateLogItem(CreateLogItemDto newLogItem)
        {
            var logItem = _mapper.Map<LogItem>(newLogItem);
            
            await _logService.AddAsync(logItem);

            return CreatedAtAction(nameof(CreateLogItem), logItem);
        }

        //PUT - Updating a log, only to be used by admins. Logs should stay permanent, edits to discrepencies should take place as a sign off or get an admin to update.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogItem(int id, UpdateLogItemDto updatedLogItem)
        {
            if (id != updatedLogItem.Id)
            {
                return BadRequest("Invalid Vehicle Id");
            }

            var logItem = await _logService.GetAsync(id);

            if (logItem == null)
            {
                return NotFound();
            }

            //Check if the values are different
            if (logItem.Discrepency == updatedLogItem.Discrepency || updatedLogItem.Discrepency == null)
            {
                updatedLogItem.Discrepency = logItem.Discrepency;
            } else if (logItem.Closed == updatedLogItem.Closed || updatedLogItem.Closed == null)
            {
                updatedLogItem.Closed = logItem.Closed;
            }

            //Map the updated vehicle to the vehicle
            _mapper.Map(updatedLogItem, logItem);

            try
            {
                await _logService.UpdateAsync(logItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _logService.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE - Delete a log, records should be permanent. Only to be used by admin.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogItem(int id)
        {
            var logItem = await _logService.GetAsync(id);

            if (logItem is null)
                return NotFound();

            await _logService.DeleteAsync(id);

            return NoContent();
        }
    }
}
