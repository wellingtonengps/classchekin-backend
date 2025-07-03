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
}
