using classcheckin.Data;
using classcheckin.DTOs;
using classcheckin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
      var students = await _context.Students.ToListAsync();
      return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO dto)
    {
        var student = new Student { Name = dto.Name, Email = dto.Email };
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok(student);
    }
}
