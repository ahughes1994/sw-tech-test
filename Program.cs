using Microsoft.EntityFrameworkCore;
using SWCodeReview.DataAccess;
using SWCodeReview.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeeContext>(options =>
{
	options.UseSqlServer(configuration.GetConnectionString("EmployeeDatabase"));
});

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
