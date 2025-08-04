using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models;

public enum SessionStatus
{
    NaoIniciada,
    EmAndamento,
    Finalizada
}

public class Session
{
  [Key]
  public Guid id { get; set; } = Guid.NewGuid();

  [Required]
  public string title { get; set; }

  public DateTime createdAt { get; set; } = DateTime.UtcNow;

  [Required]
  public TimeSpan duration { get; set; }

  public SessionStatus Status
    {
        get
        {
            var now = DateTime.UtcNow;
            if (now < createdAt) return SessionStatus.NaoIniciada;
            if (now >= createdAt && now <= createdAt + duration) return SessionStatus.EmAndamento;
            return SessionStatus.Finalizada;
        }
  }
}

