using IdentityModel;
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
                new IdentityResources.Profile()
            };

        //There are two types of scopes
        //1-resorce end points
        //2-like your claimes 
        //This list shows api's in the system
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> { new ApiResource("WT.EcommerceAdminAPI") 
                                                    { Scopes = { "EcommerceAdminAPI.admin" } },
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
                    RedirectUris={ "http://localhost:49354/signin-oidc" },
                    //Scapes means what can this access token used for 
                    AllowedScopes={ "EcommerceAdminAPI.admin", "EcommerceClientAPI.admin","openid","profile" }
                    //It means this client can have access to this api
                    
                }
            };




    }
}
