using Backend.Models;
using Backend.DTOs;

namespace Backend.DTOs.Vehicles
{
    public class GetVehicleDto
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int? Mileage { get; set; }
        public int? Hours { get; set; } 
    }
}
