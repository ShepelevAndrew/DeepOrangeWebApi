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

builder.Services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>()
                .AddScoped<IBaseRepository<Direction>, DirectionRepository>()
                .AddScoped<IBaseRepository<Technology>, TechnologyRepository>();

builder.Services.AddScoped<IBaseService<Employee>, EmployeeService>()
                .AddScoped<IBaseService<Direction>, DirectionService>()
                .AddScoped<IBaseService<Technology>, TechnologyService>();

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
