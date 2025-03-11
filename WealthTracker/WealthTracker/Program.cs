using WealthTracker.Components;
using WealthTracker.Contexts;
using WealthTracker.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WealthTracker.Models.Data;
using WealthTracker.Models.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddScoped<FetchStockService>();
builder.Services.AddScoped<UserStockMapper>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<SignupService>();


// Add user authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/access-denied";
        options.Cookie.Name = "auth_token";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Add Antiforgery
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
});

// Add IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddBlazorBootstrap();

// Add the DbContext to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Seed the database with initial data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await SeedData.SeedAssetTypesAsync(context);
    await SeedData.SeedSectorsAsync(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
