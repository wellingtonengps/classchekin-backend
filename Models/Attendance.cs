using System;
using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models
{
    public class Attendance
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid studentId { get; set; }

        [Required]
        public Guid sessionId { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
