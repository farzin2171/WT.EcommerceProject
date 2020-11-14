using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WT.Ecommerce.Services.Customers;

namespace WT.EcommerceAdminAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class CustomerInformationController : ControllerBase
    {
        private readonly ICustomerInformationService _customerInformationService;
        public CustomerInformationController(ICustomerInformationService customerInformationService)
        {
            _customerInformationService = customerInformationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int limit=10,int skip=0)
        {
            return Ok(await _customerInformationService.GetPaged(limit, skip));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CustomerInformationViewModel input)
        {
            return Ok(await _customerInformationService.Create(input));
        }


    }
}