using Microsoft.EntityFrameworkCore;
using ProjectAgileBoard.API.Data;
using ProjectAgileBoard.API.Repository;
using ProjectAgileBoard.API.Services;
using ProjectAgileBoard.API.Strategy; // ← agregar

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IStoryServices, StoryServices>();
builder.Services.AddScoped<IUsuariosServices, UsuariosServices>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// builder.Services.AddScoped<EstimationClientApi>(); ← quitar
builder.Services.AddScoped<IEstimationStrategyFactory, EstimationStrategyFactory>(); // ← agregar
builder.Services.AddScoped<PokeClientApi>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("EstimationApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["EstimationApiBaseUrl"]!);
});
builder.Services.AddHttpClient("PokeApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PokeApiBaseUrl"]!);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();