using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Movies.Services
{
    public class AuthService : IAuthService
    {
        private static readonly string roles = "roles";
        AuthSettings Settings;

        public AuthService(IOptions<AuthSettings> options)
        {
            Settings = options.Value;
        }
        // Utilice su propia lógica de validación de usuarios
        public bool ValidateUser(string username, string password)
        {
            return username.Equals("admin") && password.Equals("admin");
        }
        public string GenerateAccessToken(DateTime now, string username, TimeSpan validtime)
        {
            var expires = now.Add(validtime);
            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(
                        JwtRegisteredClaimNames.Iat,
                        new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                        ClaimValueTypes.Integer64
                    ),
                    new Claim(
                        roles,
                        "ADMIN"
                    ),
                    new Claim(
                        roles,
                        "SUPERUSUARIO"
                    )
            };
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature
            );
            var jwt = new JwtSecurityToken(
                issuer: Settings.Issuer,
                audience: Settings.Audience,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }

    public interface IAuthService {
        bool ValidateUser(string username, string password);
        string GenerateAccessToken(DateTime now, string username, TimeSpan validtime);
    }
}