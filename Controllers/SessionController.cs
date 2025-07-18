using System.Text;
using classcheckin.DTOs;
using classcheckin.Services;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

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
      
    Console.OutputEncoding = Encoding.UTF8;

    QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(session.id.ToString(), QRCodeGenerator.ECCLevel.Q);
    AsciiQRCode qRCode = new AsciiQRCode(qRCodeData);

    string qRCodeAsAscii = qRCode.GetGraphic(1);
    Console.WriteLine(qRCodeAsAscii);
  
      return Ok(new
    {
      session.id,
      session.title,
      session.createdAt,
      session.duration,
    });
  }
}

