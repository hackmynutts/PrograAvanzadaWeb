var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var fibonacciEstimates = new[] { 2, 3, 5, 8, 13, 21, 34};

app.MapGet("/api/estimation", () =>
{
    var estimate = fibonacciEstimates[Random.Shared.Next(fibonacciEstimates.Length)];
    return Results.Ok(new { estimation = estimate });
})
.WithName("GetEstimation");


app.MapGet("/api/estimationRandom", () =>
{
    var Estimates = Random.Shared.Next(1, 1033);
    return Results.Ok(new { estimation = Estimates });
})
.WithName("GetEstimationRandom");

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
