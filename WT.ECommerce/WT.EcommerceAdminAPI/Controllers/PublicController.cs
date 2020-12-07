using Microsoft.AspNetCore.Mvc;

namespace WT.EcommerceAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Public message from EcommerceAdminAPI");
        }
    }
}