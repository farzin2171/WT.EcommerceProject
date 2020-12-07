using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

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
        [HttpPost]
        public IActionResult UploadFiles(IFormCollection form)
        {

            try
            {
                foreach (var file in form.Files)
                {
                    UploadFile(file);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private static void UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty!");
            byte[] fileArray;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileArray = memoryStream.ToArray();
            }

        }
    }
}