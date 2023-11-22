namespace MXLogbookAPI.DTOs.Vehicle
{
    //We remove the ID so we do not have to manually set it.
    public class AddVehicleDto
    {
        public string VehicleMake { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public int VehicleYear { get; set; }
        public decimal? Mileage { get; set; }
        public decimal? Hours { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
