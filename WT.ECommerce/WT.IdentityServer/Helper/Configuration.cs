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
                
                new ApiScope("EcommerceAdminAPI.admin")
            };
        }
        //This list shows api's in the system
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> { new ApiResource("WT.EcommerceAdminAPI") { Scopes = { "EcommerceAdminAPI.admin" } } };

        //This is a list of clients that want to consume apis

        public static IEnumerable<Client> GetClient() =>
            new List<Client>
            {
                new Client
                {
                    ClientId="WT.EcommerceClient_1",
                    ClientSecrets={new Secret("WT.EcommerceClient_1_secret".ToSha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,

                    //Scapes means what can this access token used for 
                    AllowedScopes={ "EcommerceAdminAPI.admin" }
                    //It means this client can have access to this api
                    
                }
            };




    }
}
