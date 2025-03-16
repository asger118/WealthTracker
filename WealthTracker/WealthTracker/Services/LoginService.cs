using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WealthTracker.Contexts;
using WealthTracker.Models;
using Microsoft.AspNetCore.Identity;

public class LoginService
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string?> AuthenticateAsync(string email, string password)
    {
        var user = _dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
        if (user == null)
        {
            return "No user with this email exists";
        }

        var passwordHasher = new PasswordHasher<User>();
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return "Incorrect password";
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            await httpContext.SignInAsync(principal);
        }
        else
        {
            return "An error occurred during authentication.";
        }

        return null;
    }
}
