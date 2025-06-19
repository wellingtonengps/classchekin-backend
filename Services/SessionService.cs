using classcheckin.Data;
using classcheckin.Models;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Services;

public class SessionService
{
  private readonly AppDbContext _context;

  public SessionService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Session> createSessionAsync(string title, TimeSpan duration)
  {
    var session = new Session { title = title, duration = duration };
    _context.Sessions.Add(session);
    await _context.SaveChangesAsync();
    return session;
  }
}