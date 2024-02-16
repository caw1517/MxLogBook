using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.SignOff
{
    public class NewSignOffDto
    {
        public int Id { get; set; }
        [Required]
        public string? WorkPerformed { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public bool CompletesItem { get; set; }
        public string? UserId { get; set; }
        public int LogId { get; set; }
    }
}
