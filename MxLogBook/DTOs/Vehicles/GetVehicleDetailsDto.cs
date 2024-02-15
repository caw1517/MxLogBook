using Backend.DTOs.LogItem;

namespace Backend.DTOs.Vehicles
{
    public class GetVehicleDetailsDto
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int? Mileage { get; set; }
        public int? Hours { get; set; }
        public string? UserId { get; set; }
        public virtual IList<GetLogItemDto>? LogItems { get; set; }

    }
}
