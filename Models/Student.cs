using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models;

public class Student
{
  [Key]
  public Guid id { get; set; } = Guid.NewGuid();

  [Required]
  public string name { get; set; }

  [Required]
  public int registration { get; set; }

  [Required]
  [EmailAddress]
  public string email { get; set; }
}

