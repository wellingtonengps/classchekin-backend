using System.ComponentModel.DataAnnotations;

namespace classcheckin.Models;

public class Student
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public string Name { get; set; }

  [Required]
  [EmailAddress]
  public string Email { get; set; }
}

