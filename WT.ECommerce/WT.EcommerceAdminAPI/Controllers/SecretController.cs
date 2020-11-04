﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WT.EcommerceAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecretController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("secret message from EcommerceAdminAPI");
        }
    }
}