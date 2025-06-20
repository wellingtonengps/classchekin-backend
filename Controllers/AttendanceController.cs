using classcheckin.Data;
using classcheckin.DTOs;
using classcheckin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly AppDbContext _context;

    public AttendanceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAttendances()
    {
      var attendances = await _context.Attendances
          .Include(a => a.Student)
          .Include(a => a.Session)
          .ToListAsync();

      return Ok(attendances);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterAttendanceDTO dto)
    {
        var student = await _context.Students.FindAsync(dto.StudentId);
        var session = await _context.Sessions.FindAsync(dto.SessionId);

        if (student == null || session == null)
            return NotFound("Estudante ou Sessão não encontrada.");

        var alreadyRegistered = _context.Attendances
            .Any(a => a.StudentId == dto.StudentId && a.SessionId == dto.SessionId);

        if (alreadyRegistered)
            return Conflict("Presença já registrada.");

        var attendance = new Attendance
        {
            StudentId = dto.StudentId,
            SessionId = dto.SessionId
        };

        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Presença registrada com sucesso." });
    }
}
