using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Vehicles
{
    public class AddVehicleDto
    {
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }
        public int? Mileage { get; set; }
        public int? Hours { get; set; }
         
        //Default Timestamp
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
