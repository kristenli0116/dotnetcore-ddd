using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Turakas.Common.Configs;

namespace Turakas.Identity.Common;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(string username)
    {
        // 1.定义需要用到的calaims
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),

            // new Claim(ClaimTypes.Role, "r_admin"),
            // new Claim(JwtRegisteredClaimNames.Jti, "admin")

            //new Claim("Username","Admin"),
            //new Claim("Name","超级管理员"),
        };
        // 读取配置选项
        var jwtTokenOptions = _configuration.GetSection("JwtToken")
            .Get<JwtTokenOptions>();
        if (jwtTokenOptions is null)
        {
            return string.Empty;
        }
        // 2.从appsettings.json 读取 SecretKey 秘钥
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Secret));

        // 3.秘钥 + 加密算法，生成签名证书
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        // 4. 生成token令牌
        var jwtSecurityToken = new JwtSecurityToken(
            jwtTokenOptions.Issuer,
            jwtTokenOptions.Audience,
            claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(jwtTokenOptions.AccessExpiration),
            signingCredentials:credentials);

        // 5. 将token变为string类型
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        // 返回token
        return token;
    }
}