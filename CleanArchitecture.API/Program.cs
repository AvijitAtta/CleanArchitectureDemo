using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EmployeeDb"));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Employees.AddRange(
        new() { Name = "Alice", Email = "alice@test.com", DepartmentId = 1 },
        new() { Name = "Bob", Email = "bob@test.com", DepartmentId = 2 },
        new() { Name = "Avijit", Email = "avijit@test.com", DepartmentId = 1 },
        new() { Name = "Mark", Email = "mark@test.com", DepartmentId = 2 },
        new() { Name = "Jeson", Email = "jeson@test.com", DepartmentId = 2 },
        new() { Name = "Patrik", Email = "patrik@test.com", DepartmentId = 1 }
    );
    db.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
