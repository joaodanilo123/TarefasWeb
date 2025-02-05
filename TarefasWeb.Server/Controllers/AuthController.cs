using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TarefasWeb.Configurations;
using TarefasWeb.Data;
using TarefasWeb.DTO;
using TarefasWeb.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;

    public AuthController(IConfiguration config, AppDbContext context)
    {
        _config = config;
        _context = context;
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLoginDTO login)
    {

        var user = _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

        if (user != null)
        {
            var token = GenerateJwtToken(user);
            return Ok(new {Token =  token});
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = JwtSettings.MountJwtSettings(_config);
        var key = jwtSettings.Key;
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", user.Id.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings.ExpiresInMinutes)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}