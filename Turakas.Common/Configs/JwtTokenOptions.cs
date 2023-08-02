using System.Text.Json.Serialization;

namespace Turakas.Common.Configs;

public class JwtTokenOptions
{
    /// <summary>
    /// 这里的 JwtToken 是 ‘appsettings.json’ 中的配置名
    /// </summary>
    public const string JwtToken = "JwtToken";
    [JsonPropertyName("secret")] 
    public string Secret { get; set; }
    [JsonPropertyName("issuer")] 
    public string Issuer { get; set; }
    [JsonPropertyName("audience")] 
    public string Audience { get; set; }
    [JsonPropertyName("accessExpiration")] 
    public int AccessExpiration { get; set; }

    [JsonPropertyName("refreshExpiration")]
    public int RefreshExpiration { get; set; }
}