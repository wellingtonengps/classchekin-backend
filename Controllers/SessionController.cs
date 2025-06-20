using classcheckin.DTOs;
using classcheckin.Services;
using Microsoft.AspNetCore.Mvc;

namespace classcheckin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
  private readonly SessionService _sessionService;
  private readonly IHttpContextAccessor _httpContext;

  public SessionController(SessionService sessionService, IHttpContextAccessor httpContext)
  {
    _sessionService = sessionService;
    _httpContext = httpContext;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllSessions()
  {
    var sessions = await _sessionService.GetAllSessionsAsync();
    return Ok(sessions);
  }

  [HttpPost]
  public async Task<IActionResult> CreateSession([FromBody] CreateSessionDTO dto)
  {
      var session = await _sessionService.CreateSessionAsync(dto.title, dto.duration);
  
      return Ok(new
      {
          session.Id,
          session.Title,
          session.CreatedAt,
          session.Duration,
      });
  }
}

