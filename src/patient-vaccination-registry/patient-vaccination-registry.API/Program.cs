
using Microsoft.EntityFrameworkCore;
using patient_vaccination_registry.Application.Services;
using patient_vaccination_registry.Infrastructure.Context;
using patient_vaccination_registry.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:60996")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<VaccineRepository>();
builder.Services.AddScoped<DriveRepository>();
builder.Services.AddScoped<ApplicationRepository>();

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<VaccineService>();
builder.Services.AddScoped<DriveService>();
builder.Services.AddScoped<ApplicationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapControllers();

app.Run();
