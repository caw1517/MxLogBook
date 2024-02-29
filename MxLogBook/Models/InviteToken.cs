namespace Backend.Models
{
    public class InviteToken
    {
        public int Id { get; set; }
        public string? TokenNumber { get; set; }
        public string? UserId { get; set; }
        public int CompanyId { get; set; }
        //Defaults to true
        public bool IsValidToken { get; set; } = true;
        //Invite is valid for 3 days
        public DateTime ExpDate { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(3);
    }
}
