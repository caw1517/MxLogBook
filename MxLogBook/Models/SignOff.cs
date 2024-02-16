using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class SignOff
    {
        public int Id { get; set; }
        [Required]
        public string? WorkPerformed { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool CompletesItem { get; set; }

        [ForeignKey(nameof(UserId))]
        [Required]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey(nameof(LogId))]
        [Required]
        public int LogId { get; set; }
        public LogItem? Log { get; set; }

    }
}
