using Microsoft.EntityFrameworkCore;
using classcheckin.Models;

namespace classcheckin.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Session> Sessions => Set<Session>();
}