namespace Backend.DTOs.LogItem
{
    public class GetAllLogsDto
    {
        public int Id { get; set; }
        public string? Discrepency { get; set; }
        public bool Closed { get; set; }
        public int VehicleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ClosedOn { get; set; }

    }
}
