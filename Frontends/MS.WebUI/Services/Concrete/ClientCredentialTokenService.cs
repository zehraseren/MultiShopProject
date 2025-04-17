using MS.WebUI.Settings;
using Duende.IdentityModel.Client;
using MS.WebUI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;

namespace MS.WebUI.Services.Concrete;

public class ClientCredentialTokenService : IClientCredentialTokenService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _memoryCache;
    private readonly ServiceApiSettings _serviceApiSettings;
    private readonly ClientSettings _clientSettings;

    public ClientCredentialTokenService(HttpClient httpClient, IMemoryCache memoryCache, IOptions<ServiceApiSettings> serviceApiSettings, IOptions<ClientSettings> clientSettings)
    {
        _httpClient = httpClient;
        _memoryCache = memoryCache;
        _serviceApiSettings = serviceApiSettings.Value;
        _clientSettings = clientSettings.Value;
    }

    public async Task<string> GetToken()
    {
        if (_memoryCache.TryGetValue("MultiShopCookie", out string cachedToken))
        {
            return cachedToken;
        }

        var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        if (discoveryEndpoint.IsError)
        {
            throw new Exception("Discovery endpoint alınamadı");
        }

        var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
            ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
            Address = discoveryEndpoint.TokenEndpoint
        };

        var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

        if (tokenResponse.IsError)
        {
            throw new Exception("Token alınamadı :" + tokenResponse.ErrorDescription);
        }

        _memoryCache.Set("MultiShopCookie", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));

        return tokenResponse.AccessToken;
    }
}
