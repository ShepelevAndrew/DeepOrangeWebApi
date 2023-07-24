using System.Security.Claims;
using DeepOrangeWebApi.BLL.Models.DTOs;
using DeepOrangeWebApi.BLL.Services.Implementations;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Implementations;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"),
    options => options.MigrationsAssembly("DeepOrangeWebApi")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://localhost:7004";
        options.Audience = "DeepOrangeApi";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Employee", policyEmployee =>
    {
        policyEmployee.RequireClaim(ClaimTypes.Role, "Employee");
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:5013")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IBaseRepository<Profile>, ProfileRepository>()
                .AddScoped<IBaseRepository<Direction>, DirectionRepository>()
                .AddScoped<ITechnologyRepository, TechnologyRepository>();

builder.Services.AddScoped<IServiceBase<ProfileCreateDto, ProfileReadDto>, ProfileService>()
                .AddScoped<IServiceBase<DirectionCreateDto, DirectionReadDto>, DirectionService>()
                .AddScoped<ITechnologyService, TechnologyService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
