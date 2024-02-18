using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class SignOff
    {
        public int Id { get; set; }
        public string? WorkPerformed { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool CompletesItem { get; set; }

        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey(nameof(LogId))]
        public int LogId { get; set; }
        public LogItem? Log { get; set; }

    }
}
