using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Security.Claims;

namespace CajaAhorro.WEBSERVICE.Clases
{
    internal static class TokenGenerator
    {

        public static string GenerarTokenJwt(string proyecto)
        {
            //Configuracion appSettings
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var isuserToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securitykey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);

            //Crear claims Identity

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, proyecto) });

            // crear token 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: isuserToken,
               subject: claimsIdentity,
               notBefore: DateTime.UtcNow,
               expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
               signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;


        }


    }
}