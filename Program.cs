using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AssetManagement;Trusted_Connection=True;TrustServerCertificate=True;") // Corrigido
);

builder.Services.AddControllers(); // Habilitar controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar a documentação Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Habilita os endpoints dos controladores

app.Run();
