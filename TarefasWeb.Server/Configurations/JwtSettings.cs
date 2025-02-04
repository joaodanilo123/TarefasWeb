using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TarefasWeb.Configurations
{
    public class JwtSettings
    {
        public required SymmetricSecurityKey Key { get; init; }
        public required string Issuer { get; init; }
        public required string Audience { get; init; }

        public static JwtSettings MountJwtSettings(WebApplicationBuilder builder)
        {
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");

            if (jwtSettings == null)
            {
                throw new Exception("JWT Settings Not Found!");
            }

            var key = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            if (key == null)
            {
                throw new Exception("JWT Setting \"Key\" not found!");
            }
            if (issuer == null)
            {
                throw new Exception("JWT Setting \"Issuer\" not found!");
            }
            if (audience == null)
            {
                throw new Exception("JWT Setting \"Audience\" not found!");
            }

            var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

            return new JwtSettings()
            {
                Audience = audience,
                Issuer = issuer,
                Key = secureKey,
            };
        }

        public TokenValidationParameters createTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = Key,
            };
        }
    }
}
