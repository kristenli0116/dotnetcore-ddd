using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Turakas.Common.Configs;
using Turakas.Identity.Common;

namespace Turakas.Identity.Extensions;

public static class CustomExtensionMethods
{
    /// <summary>
    ///     注册服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new JwtHelper(configuration));
        services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.JwtToken));
    }
}