using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Turakas.Common.Configs;

namespace Turakas.Common;

public static class CommonExtensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        // "JwtToken": {
        //     "Secret": "cOqEhDFUucaAAy90c2ZthBCLybWKrbao",// 秘钥
        //     "Issuer": "http://localhost:5000",// 颁发者
        //     "Audience": "http://localhost:5001",// 颁发服务
        //     "AccessExpiration": 30, 
        //     "RefreshExpiration": 60
        // },
        // 绑定方式：
        // 方式一：jwtConfig.Bind(new JwtTokenOptions()) 具有相同作用
        // 方式二：通过 Get<T> 绑定并返回指定类型，
        var jwtToken = configuration.GetSection(JwtTokenOptions.JwtToken).Get<JwtTokenOptions>();
        if (jwtToken is null)
        {
            return services;
        }
        services.AddAuthentication(x => x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
            .AddCookie()
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken.Secret)), // 签名证书
                    ValidIssuer = jwtToken.Issuer, // 颁发者
                    ValidAudience = jwtToken.Audience, // 颁发服务
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });
        return services;
    }
}