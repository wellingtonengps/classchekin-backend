using classcheckin.Data;
using classcheckin.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=frequencia.db"));

builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<AttendanceService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
