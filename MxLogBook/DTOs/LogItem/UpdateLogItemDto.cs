namespace Backend.DTOs.LogItem
{
    public class UpdateLogItemDto
    {
        public int Id { get; set; }
        public string? Discrepency { get; set; }
        public bool? Closed { get; set; } = false;
    }
}
