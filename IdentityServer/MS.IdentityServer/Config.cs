using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MS.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("ResourceCatalog"){ Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
        new ApiResource("ResourceDiscount"){ Scopes = { "DiscountFullPermission"} },
        new ApiResource("ResourceOrder"){ Scopes = { "OrderFullPermission"} },
        new ApiResource("ResourceCargo"){ Scopes = { "CargoFullPermission"} },
        new ApiResource("ResourceBasket"){ Scopes = { "BasketFullPermission"} },
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email(),
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("CatalogFullPermission", "Full access to catalog"),
        new ApiScope("CatalogReadPermission", "Read access to catalog"),
        new ApiScope("DiscountFullPermission", "Full access to discount"),
        new ApiScope("OrderFullPermission", "Full access to order"),
        new ApiScope("CargoFullPermission", "Full access to cargo"),
        new ApiScope("BasketFullPermission", "Full access to basket"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        //Visitor
        new Client
        {
            ClientId = "MultiShopVisitorId",
            ClientName = "MultiShop Visitor User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopvisitorsecret".Sha256()) },
            AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission" },
            AllowAccessTokensViaBrowser = true
        },

        //Manager
        new Client
        {
            ClientId = "MultiShopManagerId",
            ClientName = "MultiShop Manager User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopmanagersecret".Sha256()) },
            AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "BasketFullPermission" },

        },

        //Admin
        new Client
        {
            ClientId = "MultiShopAdminId",
            ClientName = "MultiShop Admin User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopadminsecret".Sha256()) },
            AllowedScopes = {
                "CatalogFullPermission",
                "CatalogReadPermission",
                "DiscountFullPermission",
                "OrderFullPermission",
                "CargoFullPermission",
                "BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            },
            AccessTokenLifetime = 600
        }
    };
}
