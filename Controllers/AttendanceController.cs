using classcheckin.DTOs;
using classcheckin.Services;
using Microsoft.AspNetCore.Mvc;

namespace classcheckin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
  private readonly AttendanceService _attendanceService;

  public AttendanceController(AttendanceService attendanceService)
  {
    _attendanceService = attendanceService;
  }

  [HttpPost]
  public async Task<IActionResult> RegisterAttendance([FromBody] AttendanceDTO dto)
  {
    var attendance = await _attendanceService.RegisterAttendanceAsync(dto.studentId, dto.sessionId);

    return Ok(new
    {
      attendance
    });
  }


  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var attendances = await _attendanceService.GetAllAsync();
    return Ok(attendances);
  }


  [HttpGet("student/{studentId}")]
  public async Task<IActionResult> GetByStudentId(Guid studentId)
  {
    var list = await _attendanceService.GetByStudentIdAsync(studentId);
    return Ok(list);
  }

  [HttpGet("session/{sessionId}")]
  public async Task<IActionResult> GetBySessionId(Guid sessionId)
  {
    var list = await _attendanceService.GetBySessionIdAsync(sessionId);
    if (!list.Any())
      return NotFound($"Nenhuma presença encontrada para a sessão com ID {sessionId}");
    return Ok(list);
  }
}
