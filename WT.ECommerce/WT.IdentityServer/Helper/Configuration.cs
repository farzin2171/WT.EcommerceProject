using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WT.IdentityServer.Helper
{
    public static class Configuration
    {

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                
                new ApiScope("EcommerceAdminAPI.admin"),
                new ApiScope("EcommerceClientAPI.admin"),

            };
        }

        //User information resources
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name="WT.scope",
                    UserClaims =
                    {
                        "WT.level"
                    }
                }
            };

        //There are two types of scopes
        //1-resorce end points
        //2-like your claimes 
        //This list shows api's in the system
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> { new ApiResource("WT.EcommerceAdminAPI") 
                                                    { Scopes = { "EcommerceAdminAPI.admin" },UserClaims={ "WT.api.level"} },
                                    new ApiResource("WT.EcommerceClientAPI")
                                                    { Scopes = { "EcommerceClientAPI.admin" } }
                                  };

        //This is a list of clients that want to consume apis

        public static IEnumerable<Client> GetClient() =>
            new List<Client>
            {
                new Client
                {
                    ClientId="WT.EcommerceClient_1",
                    ClientSecrets={new Secret("WT.EcommerceClient_1_secret".ToSha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,  //Client credential is usefull for Api to Api commnication

                    //Scapes means what can this access token used for 
                    AllowedScopes={ "EcommerceAdminAPI.admin" }
                    //It means this client can have access to this api
                    
                },
                 new Client
                {
                    ClientId="WT.EcommerceClient_MVC",
                    ClientSecrets={new Secret("WT.EcommerceClient_MVC_secret".ToSha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RedirectUris={ "https://localhost:44383/signin-oidc" },
                    //Scapes means what can this access token used for 
                    AllowedScopes={ 
                                     "EcommerceAdminAPI.admin",
                                     "EcommerceClientAPI.admin",
                                     IdentityServerConstants.StandardScopes.OpenId,
                                     IdentityServerConstants.StandardScopes.Profile,
                                     "WT.scope"
                                   },
                    //It means this client can have access to this api
                    RequireConsent=false,
                    //Puts all the claimes in the id token
                    //AlwaysIncludeUserClaimsInIdToken=true
                    AllowOfflineAccess=true
                    
                },
                 new Client
                 {
                    ClientId="WT.EcommerceClient_JS",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    RequireClientSecret=false,
                    RequirePkce=true,
                    RedirectUris={ "https://localhost:44383/Home/signIn" },
                    AllowedCorsOrigins={"https://localhost:44383"},
                     AllowedScopes={
                                     "EcommerceAdminAPI.admin",
                                     "EcommerceClientAPI.admin",
                                     IdentityServerConstants.StandardScopes.OpenId,
                                     IdentityServerConstants.StandardScopes.Profile,
                                     "WT.scope"
                                   },
                     RequireConsent=false,
                     AllowAccessTokensViaBrowser=true,
                 }
                 
            };




    }
}
