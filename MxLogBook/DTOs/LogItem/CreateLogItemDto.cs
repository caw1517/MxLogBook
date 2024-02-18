using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.LogItem
{
    public class CreateLogItemDto
    {
        public int Id { get; set; }
        //TODO - Add Task Item Relation
        public string? Discrepency { get; set; }
        //Change to Enum Later
        public bool Closed { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }
        [Required]
        public int VehicleId { get; set; }
    }
}
