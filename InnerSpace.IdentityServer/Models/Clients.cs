using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace InnerSpace.IdentityServer.Models
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
             
            new Client {
    ClientId = "dev-read-api",
    ClientName = "InnerSpace read api",
    AllowAccessTokensViaBrowser= true,
    AllowedGrantTypes = GrantTypes.Implicit,
    AllowedScopes = new List<string>
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        IdentityServerConstants.StandardScopes.Email,
         IdentityServerConstants.StandardScopes.OfflineAccess,
        "role",
        "read_only"
    },
    RedirectUris = new List<string> {"https://localhost:44370/oauth2-redirect.html"},
    PostLogoutRedirectUris = new List<string> { "https://localhost:44370/" }
}
        };
        }
    }
}
