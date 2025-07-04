using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace classcheckin.Models;

public class Attendance
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid StudentId { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; }

    [Required]
    public Guid SessionId { get; set; }

    [ForeignKey("SessionId")]
    public Session Session { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}