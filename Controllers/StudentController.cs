using classcheckin.Data;
using classcheckin.DTOs;
using classcheckin.Models;
using classcheckin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService, AppDbContext context)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO dto)
    {
        var student = await _studentService.CreateStudentAsync(dto.name, dto.registration, dto.email);
     
        return Ok(student);
    }
}
