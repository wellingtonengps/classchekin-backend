using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models;

public class Session
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public string Title { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  [Required]
  public TimeSpan Duration { get; set; }
}

