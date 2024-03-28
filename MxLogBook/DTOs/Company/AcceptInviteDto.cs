namespace Backend.DTOs.Company
{
    public class AcceptInviteDto
    {
        public string? TokenNumber { get; set; }
        public string? UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
