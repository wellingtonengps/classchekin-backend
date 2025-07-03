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
      attendance.id,
      attendance.studentId,
      attendance.sessionId,
      attendance.createdAt
    });
  }
}
