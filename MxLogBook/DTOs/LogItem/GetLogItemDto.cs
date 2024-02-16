using Backend.DTOs.Auth;
using Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.LogItem
{
    public class GetLogItemDto
    {
        public int Id { get; set; }
        //TODO - Add Task Item Relation
        public string? Discrepency { get; set; }
        //Change to Enum Later
        public bool Closed { get; set; }
        public int VehicleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public virtual GetUserBasicDto? User{ get; set; }

    }
}
