﻿using MS.WebUI.Settings;
using System.Security.Claims;
using Duende.IdentityModel.Client;
using MS.WebUI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using MS.UI.DtoLayer.IdentityDtos.LoginDtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace MS.WebUI.Services.Concrete;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly ClientSettings _clientSettings;
    private readonly ServiceApiSettings _serviceApiSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityService(HttpClient httpClient, IOptions<ClientSettings> clientSettings, IHttpContextAccessor httpContextAccessor, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _clientSettings = clientSettings.Value; // ClientSettings class olduğu için başına IOptions koyulur ve değerlerine Value ile erişilir.
        _serviceApiSettings = serviceApiSettings.Value;
    }

    public async Task<bool> GetRefreshToken()
    {
        var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false,
            }
        });

        var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

        RefreshTokenRequest refreshTokenRequest = new()
        {
            ClientId = _clientSettings.MultiShopManagerClient.ClientId,
            ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
            RefreshToken = refreshToken,
            Address = discoveryEndpoint.TokenEndpoint,
        };

        var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

        var authenticationToken = new List<AuthenticationToken>()
        {
            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.AccessToken,
                Value = token.AccessToken
            },

            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.RefreshToken,
                Value = token.RefreshToken
            },

            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.ExpiresIn,
                Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
            }
        };

        var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();

        var properties = result.Properties;
        properties.StoreTokens(authenticationToken);

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties); // Kullanıcı giriş yapmış gibi gösterilir

        return true;
    }

    // Kullanıcıyı giriş yapma işlemi
    public async Task<bool> SignIn(SignInDto signInDto)
    {
        // Discovery document almak için istemciye istek gönderilir.
        var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,  // Sunucunun adresi
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false, // HTTPS zorunlu değil
            }
        });

        // Kullanıcı bilgilerini almak için token isteği oluşturuluyor.
        var passwordTokenRequest = new PasswordTokenRequest
        {
            ClientId = _clientSettings.MultiShopManagerClient.ClientId, // ClientId ClientSettings'ten alınır
            ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret, // ClientSecret ClientSettings'ten alınır
            UserName = signInDto.Username,
            Password = signInDto.Password,
            Address = discoveryEndpoint.TokenEndpoint
        };

        // Token alınır
        var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        // Kullanıcı bilgilerini almak için istek yapılır
        var userInfoRequest = new UserInfoRequest
        {
            Token = token.AccessToken, // Alınan AccessToken kullanılarak kullanıcı bilgisi alınır
            Address = discoveryEndpoint.UserInfoEndpoint
        };

        var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

        // Kullanıcı bilgileri kullanılarak ClaimsIdentity oluşturulur
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

        // ClaimsPrincipal oluşturulur
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var authProperties = new AuthenticationProperties();

        // Token'lar authProperties'e eklenir
        authProperties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.AccessToken, // Erişim token'ı
                Value = token.AccessToken
            },

            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.RefreshToken, // Yenileme token'ı
                Value = token.RefreshToken
            },

            new AuthenticationToken()
            {
                Name = OpenIdConnectParameterNames.ExpiresIn, // Token'ın bitiş süresi
                Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
            }
        });

        authProperties.IsPersistent = false; // Çerez kalıcı değil

        // Kullanıcı sisteme giriş yapar
        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

        return true; // Giriş başarılı
    }
}
