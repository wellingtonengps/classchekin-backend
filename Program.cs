using classcheckin.Data;
using classcheckin.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=frequencia.db"));

builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();

builder.Services.AddControllers();
var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();
app.Run("http://0.0.0.0:5202");
