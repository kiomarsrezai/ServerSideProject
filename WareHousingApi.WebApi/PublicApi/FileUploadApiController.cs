using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;

namespace WareHousingApi.WebApi.PublicApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadApiController : ControllerBase
    {
        private readonly IWebHostEnvironment _hosting;

        public FileUploadApiController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }

        [HttpPost]
        [Route("ProductImageUpload")]
        public ApiResult<string> ProductImageUpload(IEnumerable<IFormFile> imagearray)
        {
            var upload = Path.Combine(_hosting.WebRootPath, "Upload\\ProductImage\\");
            var filename = "";
            try
            {
                foreach (var item in imagearray)
                {
                    filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                    using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                    {
                        item.CopyTo(fs);
                    }
                }
                //return Ok("https://" + HttpContext.Request.Headers.Host + "//Upload/ProductImage/" + filename);
                return Ok("https://" + HttpContext.Request.Headers.Host + "//Upload/UserImage/" + filename);

            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("UserImageUpload")]
        public ApiResult<string> UserImageUpload(IEnumerable<IFormFile> imagearray)
        {
            var upload = Path.Combine(_hosting.WebRootPath, "Upload\\UserImage\\");
            var filename = "";
            try
            {
                foreach (var item in imagearray)
                {
                    filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                    using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                    {
                        item.CopyTo(fs);
                    }
                }
                return Ok("https://" + HttpContext.Request.Headers.Host + "//Upload/UserImage/" + filename);
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }
    }
}