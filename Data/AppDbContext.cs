using Microsoft.EntityFrameworkCore;
using classcheckin.Models;

namespace classcheckin.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Session> Sessions => Set<Session>();
<<<<<<< HEAD
=======
  public DbSet<Student> Students => Set<Student>();
>>>>>>> 7fc9ae1e09666b9f3d366b43cf6ae54647c038d0
  public DbSet<Attendance> Attendances => Set<Attendance>();
}