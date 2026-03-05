using Microsoft.EntityFrameworkCore;
using ProjectAgileBoard.API.Data;
using ProjectAgileBoard.API.Repository;
using ProjectAgileBoard.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IStoryServices, StoryServices>();
builder.Services.AddScoped<EstimationClientApi>();

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//llamar a la API de estimación
builder.Services.AddHttpClient("EstimationApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["EstimationApiBaseUrl"]!);
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
