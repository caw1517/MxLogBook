namespace Backend.DTOs.Company
{
    public class CreateInviteTokenDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? UserId { get; set; }
    }
}
