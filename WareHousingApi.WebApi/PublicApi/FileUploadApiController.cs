using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.WebFramework.StandardApiResult;

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
        public ApiResponse ProductImageUpload(IEnumerable<IFormFile> imagearray)
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
                return new ApiResponse
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = "https://" + HttpContext.Request.Headers.Host + "//Upload/ProductImage/" + filename
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ServerError,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
        }

        [HttpPost]
        [Route("UserImageUpload")]
        public ApiResponse UserImageUpload(IEnumerable<IFormFile> imagearray)
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
                return new ApiResponse
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = "https://" + HttpContext.Request.Headers.Host + "//Upload/UserImage/" + filename
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ServerError,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
        }
    }
}