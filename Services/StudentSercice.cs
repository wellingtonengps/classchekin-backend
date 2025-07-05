using classcheckin.Data;
using classcheckin.Models;
using Microsoft.EntityFrameworkCore;

namespace classcheckin.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudentAsync(string name, int registration, string email)
        {
            var student = new Student { name = name, registration = registration, email = email };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
