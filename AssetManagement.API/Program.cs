using AssetManagement.Application.Interfaces;
using AssetManagement.Application.Services;
using AssetManagement.Infrastructure.Persistence;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AssetManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IEquipmentAppService, EquipmentAppService>();
services.AddScoped<IEquipmentDomainService, EquipmentDomainService>();
services.AddScoped<IEquipmentRepository, EquipmentRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
