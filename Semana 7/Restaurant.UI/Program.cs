using Restaurant.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Leer correctamente la URL desde appsettings (asegúrate de que "ApiBaseUrl" sea una cadena en appsettings.json)
var apiBase = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? "http://localhost:5100/";

// Registrar typed client para Orders API
builder.Services.AddHttpClient<IOrdersAPIClient, OrdersAPIClient>(client =>
{
    client.BaseAddress = new System.Uri(apiBase);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute("default", "{controller=Orders}/{action=Index}/{id?}");

app.Run();
