namespace Backend.DTOs.Company
{
    public class GetInviteTokenDto
    {
        public string? TokenNumber { get; set; }
        public string? UserId { get; set; }
        public int CompanyId { get; set; }
        public bool IsValidToken { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
