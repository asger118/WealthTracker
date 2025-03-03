using BlazorStockApp.Components;
using BlazorStockApp.Data.Contexts;
using BlazorStockApp.Services;
using BlazorStockApp.Shared.Mappers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<FetchStockService>();
builder.Services.AddTransient<IStockMapper, StockMapper>();

// Add user authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/access-denied";
        options.Cookie.Name = "auth_token";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Add the DbContext to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); ;

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorStockApp.Client._Imports).Assembly);

app.Run();

// Create migration
// dotnet ef migrations add 0001-initial --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
// Update database with migration
// dotnet ef database update --project BlazorStockApp.Data --startup-project BlazorStockApp/BlazorStockApp
