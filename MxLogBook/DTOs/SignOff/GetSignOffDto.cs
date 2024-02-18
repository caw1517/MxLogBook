using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs.SignOff
{
    public class GetSignOffDto
    {
        public string? WorkPerformed { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.Now;
        public bool CompletesItem { get; set; }

    }
}
