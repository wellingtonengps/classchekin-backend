using classcheckin.Data;
using classcheckin.Models;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Services;

public class AttendanceService
{
  private readonly AppDbContext _context;

  public AttendanceService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Attendance> RegisterAttendanceAsync(Guid studentId, Guid sessionId)
  {
    var attendance = new Attendance
    {
      studentId = studentId,
      sessionId = sessionId
    };

    _context.Attendances.Add(attendance);
    await _context.SaveChangesAsync();

    return attendance;
  }

  public async Task<List<Attendance>> GetAllAsync()
  {
    return await _context.Attendances
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<List<Attendance>> GetByStudentIdAsync(Guid studentId)
  {
    return await _context.Attendances
      .Where(a => a.studentId == studentId)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<List<Attendance>> GetBySessionIdAsync(Guid sessionId)
  {
    return await _context.Attendances
      .Where(a => a.sessionId == sessionId)
      .AsNoTracking()
      .ToListAsync();
  }
}
