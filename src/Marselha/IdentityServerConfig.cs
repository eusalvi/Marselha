using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Marselha
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("perth", "Perth Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "corporatedashboard",
                    ClientName = "Corporate Dashboard OpenId Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RedirectUris = { "http://localhost:4200/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback-oidc" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "perth"
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
