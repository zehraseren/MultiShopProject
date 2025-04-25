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
        new ApiResource("ResourceComment"){ Scopes = { "CommentFullPermission"} },
        new ApiResource("ResourcePayment"){ Scopes = { "PaymentFullPermission"} },
        new ApiResource("ResourceImage"){ Scopes = { "ImageFullPermission" } },
        new ApiResource("ResourceOcelot"){ Scopes = { "OcelotFullPermission"} },
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
        new ApiScope("CommentFullPermission", "Full access to comment"),
        new ApiScope("PaymentFullPermission", "Full access to payment"),
        new ApiScope("ImageFullPermission", "Full access to image"),
        new ApiScope("OcelotFullPermission", "Full access to ocelot"),
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
            AllowedScopes = {
                "CatalogReadPermission",
                "CatalogFullPermission",
                "CommentFullPermission",
                "ImageFullPermission",
                "OcelotFullPermission",
             IdentityServerConstants.LocalApi.ScopeName
            },
            AllowAccessTokensViaBrowser = true
        },

        //Manager
        new Client
        {
            ClientId = "MultiShopManagerId",
            ClientName = "MultiShop Manager User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopmanagersecret".Sha256()) },
            AllowedScopes = {
                "CatalogReadPermission",
                "CatalogFullPermission",
                "BasketFullPermission",
                "CommentFullPermission",
                "PaymentFullPermission",
                "ImageFullPermission",
                "DiscountFullPermission",
                "OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            },

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
                "CommentFullPermission",
                "PaymentFullPermission",
                "ImageFullPermission",
                "OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            },
            AccessTokenLifetime = 600
        }
    };
}
