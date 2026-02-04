using MVCPersonaWeb.API.Data;
using MVCPersonaWeb.API.Repositories;
using MVCPersonaWeb.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Leer cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar repositorio y servicio
builder.Services.AddScoped<IPersonaRepository>(sp => new PersonaRepositoryAdo(connectionString));
builder.Services.AddScoped<IPersonaService, PersonaService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        options.AddPolicy("UIPolicy", policy =>
        {
            policy.WithOrigins("http://localhost:5128") // Reemplaza con la URL de tu aplicación frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
});

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
