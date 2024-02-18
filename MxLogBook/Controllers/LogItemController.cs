using AutoMapper;
using Backend.DTOs.LogItem;
using Backend.DTOs.Vehicles;
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

        public LogItemController(IMapper mapper, ILogItemService logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        //GET: ALL LOG ITEMS - SHOULDN'T BE USED, ONLY TO BE USED BY ADMIN - THINK ABOUT DELETING
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllLogsDto>>> GetLogItems()
        {
            var logs = await _logService.GetAllAsync();
            var records = _mapper.Map<List<GetAllLogsDto>>(logs);
            return Ok(records);
        }

        //GET: SINGLE LOG ITEM - USED IN THE CONTEXT OF OPENING A SINGLE LOG ITEM
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

        //GET: MULTIPLE ITEMS ASSOCIATED WITH SPECIFIC VEHICLE - USED BY PEOPLE THAT OWN VEHICLE / HAVE ACCESS VIA COMPANY
        [HttpGet("logs/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<GetLogItemDto>>> GetLogItemByVehicle(int vehicleId)
        {
            var logs = await _logService.GetAllByVehicleId(vehicleId);
            var records = _mapper.Map<List<GetLogItemDto>>(logs);

            return Ok(records);
        }

        //POST: CREATE A NEW LOG, CAN BE USED BY ANYONE AUTHORIZED.
        [HttpPost]
        public async Task<ActionResult<CreateLogItemDto>> CreateLogItem(CreateLogItemDto newLogItem)
        {
            //Get the user id from the header
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity.FindFirst("uid").Value;

            //Add that as the user's Id
            newLogItem.UserId = userIdClaim;

            //Map
            var logItem = _mapper.Map<LogItem>(newLogItem);
            
            await _logService.AddAsync(logItem);

            return CreatedAtAction(nameof(CreateLogItem), logItem);
        }

        //PUT: UPDATING A LOG, ONLY TO BE USED BY ADMINS. LOGS SHOULD STAY PERMANENT, EDITS TO DISCREPENCIES SHOULD TAKE PLACE AS A SIGN OFF OR GET AN ADMIN TO UPDATE.
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

        //DELETE - DELETE A LOG, RECORDS SHOULD BE PERMANENT. ONLY TO BE USED BY ADMIN.
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
