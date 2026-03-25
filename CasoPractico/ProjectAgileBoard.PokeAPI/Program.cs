using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

//consumimos la api de pokeapi para obtener la imagen del pokemon segun su id, y redireccionamos a la imagen
app.MapGet("/api/v2/pokemon/{id:int}", async (int id, HttpClient http) =>
{
    var response = await http.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");

    using var doc = JsonDocument.Parse(response);

    //RootElement -> sprites -> front_default
    var imageUrl = doc.RootElement
        .GetProperty("sprites")
        .GetProperty("front_default")
        .GetString();

    return Results.Redirect(imageUrl!);
});

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
