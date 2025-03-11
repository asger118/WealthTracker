using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WealthTracker.Contexts;
using WealthTracker.Models;
using WealthTracker.Models.ViewModels;

public class SignupService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NavigationManager _navigationManager;

    public SignupService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, NavigationManager navigationManager)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _navigationManager = navigationManager;
    }

    public async Task<string?> RegisterUser(SignupViewModel model)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        if (user != null)
        {
            return "User already exists";
        }

        var newUser = new User
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Role = "user"
        };

        // Hash the password
        var passwordHasher = new PasswordHasher<User>();
        newUser.Password = passwordHasher.HashPassword(newUser, model.Password);

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        // Authentication successful, proceed with login
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.GivenName, newUser.FirstName),
            new Claim(ClaimTypes.Surname, newUser.LastName),
            new Claim(ClaimTypes.Role, "user")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            await httpContext.SignInAsync(principal);
            _navigationManager.NavigateTo("/");
            return null;
        }
        else
        {
            return "An error occurred during authentication.";
        }
    }
}
