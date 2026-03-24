using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/api/v2/pokemon/{id}", (int id) =>
{
    string imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";
    return Results.Ok(new { imageUrl });
}).WithName("GetPokemonImageById");

app.MapGet("/api/PokeNumber", () =>
{
    int pokeID = Random.Shared.Next(1, 151);
    return Results.Ok(new { pokeID = pokeID });
})
.WithName("GetPokeNumber");

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
