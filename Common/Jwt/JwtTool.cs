using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Web_Api.Common.Jwt;

public class JwtTool
{
    private SymmetricSecurityKey key;
    private string Iss;
    private string Sub;
    private int Minute;
    public JwtTool(IConfiguration configuration)
    {
        key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Secret"]));
        Iss = configuration["JwtConfig:Iss"];
        Sub = configuration["JwtConfig:Sub"];
        Minute= Convert.ToInt32(configuration["JwtConfig:Minute"]);
    }
    public string GenerateJwt(List<string> roles)
    {
        var jwt = new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new("iss", Iss),
                new("sub", Sub),
                new(ClaimTypes.Role, string.Join(',', roles)),
            }),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.Now.AddMinutes(Minute)
        });
        return jwt;
    }
}