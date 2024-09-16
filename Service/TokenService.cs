using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Microsoft.IdentityModel.Tokens;

namespace Aviario_Campo_Alegre.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            this._config = config;
        }
        public string GenerateToken(AdministradorModel administradorModel)
        {
            var key = _config.GetSection("Jwt").ToString() ?? "123456";
            /*var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "123456"));
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new []{
                    new Claim(type:ClaimTypes.Email, value:adminiModelModel.Email),
                    new Claim(type:ClaimTypes.Role, value:adminiModelModel.Perfil)
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);*/
            if(string.IsNullOrEmpty(key)) return string.Empty;
                
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> (){ 
                new Claim("Email",administradorModel.Email), 
                new Claim("Perfil", administradorModel.Perfil),
                new Claim(ClaimTypes.Role,administradorModel.Perfil)};
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
           
        }
    }
}