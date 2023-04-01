using DeepOrangeWebApi.BLL.Services.Implementations;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Implementations;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"),
    options => options.MigrationsAssembly("DeepOrangeWebApi")));

builder.Services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
