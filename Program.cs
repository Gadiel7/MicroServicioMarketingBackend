using Microsoft.EntityFrameworkCore;
using MicroServicioMarketingBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Conexión a SQL Server
var connection = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration["DEFAULT_CONNECTION"]
    ?? "Server=db;Database=StudentDB;User Id=sa;Password=Your_password123;TrustServerCertificate=True;";

builder.Services.AddDbContext<EstudianteContext>(opt => opt.UseSqlServer(connection));

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Crear DB si no existe
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EstudianteContext>();
    db.Database.EnsureCreated();
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowReact");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
