using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WT.Ecommerce.Domain.Models;

namespace WT.EcommerceAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecretController : ControllerBase
    {
        private IIdentityContext _identityContext;

        public SecretController(IIdentityContext identityContext)
        {
            _identityContext = identityContext;
        }
        public IActionResult Index()
        {
            var x= _identityContext.Claims;
            return Ok("secret message from EcommerceAdminAPI");
        }
    }
}