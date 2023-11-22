namespace MXLogbookAPI.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleMake { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public int VehicleYear { get; set; }
        public decimal? Mileage { get; set; }
        public decimal? Hours { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
