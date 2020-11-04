using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WT.EcommerceClientAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallAdminController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        public CallAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Retrive access Token
            var serverClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44365/");

            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
                 new ClientCredentialsTokenRequest
                 {
                     Address = discoveryDocument.TokenEndpoint,
                     ClientId = "WT.EcommerceClient_1",
                     ClientSecret = "WT.EcommerceClient_1_secret",
                     Scope = "EcommerceAdminAPI.admin"

                 });


            //Retrive secret data
            var apiClient = _httpClientFactory.CreateClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var sercret = await apiClient.GetAsync("https://localhost:44382/api/secret");

            return Ok(sercret.Content);
        }
    }
}