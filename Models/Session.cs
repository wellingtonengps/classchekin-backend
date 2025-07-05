using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models;

public class Session
{
  [Key]
  public Guid id { get; set; } = Guid.NewGuid();

  [Required]
  public string title { get; set; }

  public DateTime createdAt { get; set; } = DateTime.UtcNow;

  [Required]
  public TimeSpan duration { get; set; }
}

