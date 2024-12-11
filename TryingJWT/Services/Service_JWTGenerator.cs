using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TryingJWT.Services {
    public class Service_JWTGenerator
    {
        private readonly IConfiguration _configuration;

        public Service_JWTGenerator(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GenerateToken(string userId) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"] ?? "0");
            Console.WriteLine(_configuration["JwtSettings:Key" ?? "0"]);
            Console.WriteLine(_configuration["JwtSettings:Audience" ?? "0"]);
            Console.WriteLine(_configuration["JwtSettings:Issuer" ?? "0"]);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity([new Claim("id", userId), new Claim("Audience", _configuration["JwtSettings:Audience"] ?? "http://localhost:5013"), new Claim("Issuer", _configuration["JwtSettings:Issuer"] ?? "http://localhost:5013")]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}