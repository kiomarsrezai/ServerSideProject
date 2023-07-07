using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductLocationApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IProductLocationRepository _location;

        public ProductLocationApiController(IUnitOfWork context, IProductLocationRepository location)
        {
            _context = context;
            _location = location;
        }

        [HttpGet("GetProductLocation")]
        public ApiResponse<IEnumerable<ProductLocations_Tbl>> GetProductLocation([FromBody] int wareHouseID)
        {
            var productLocationList = _context.productLocationUW.Get(pl => pl.WareHouseID == wareHouseID);
            return new ApiResponse<IEnumerable<ProductLocations_Tbl>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = productLocationList
            };
        }

        [HttpPost]
        [Route("CreateLocationApi")]
        public ApiResponse Create([FromForm] ProductLocationCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (model.ProductLocationAddress == "") return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };
            //کنترل تکراری نبودن اطلاعات
            var getLocation = _context.productLocationUW.Get(pl => pl.ProductLocationAddress == model.ProductLocationAddress && pl.WareHouseID == model.WareHouseID);
            if (getLocation.Count() > 0)
            {
                //تکراری
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DuplicateInformation,
                    Message = ApiResultStatusCode.DuplicateInformation.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            try
            {
                ProductLocations_Tbl PL = new ProductLocations_Tbl
                {
                    CreateDateTime = DateTime.Now,
                    WareHouseID = model.WareHouseID,
                    ProductLocationAddress = model.ProductLocationAddress,
                    UserID = model.UserID
                };
                _context.productLocationUW.Create(PL);
                _context.Save();
                return new ApiResponse<ProductLocations_Tbl>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = PL
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

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductLocations_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<ProductLocations_Tbl> GetById([FromQuery] int productlocationid)
        {
            var plocation = _context.productLocationUW.GetById(productlocationid);
            return new ApiResponse<ProductLocations_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = plocation
            };
        }

        [HttpPut("{id}")]
        [Route("UpdateProductLocation")]
        [ProducesResponseType(typeof(ProductLocations_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromForm] ProductLocationEditModel model)
        {
            if (model.ProductLocationID == 0) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            //کنترل تکراری بودن
            var getPlocation = _context.productLocationUW.Get(p => p.ProductLocationAddress == model.ProductLocationAddressE && p.WareHouseID == model.WareHouseIDE);
            if (getPlocation.Count() > 0)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ServerError,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }

            return new ApiResponse<ProductLocations_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = _location.UpdateProductLocation(model)
            };
        }

        [HttpGet("ProductLocationListDropDown")]
        public ApiResponse ProductLocationList(int WareHouseID)
        {
            IEnumerable<DropDownDto> productLocationList = _context.productLocationUW.
                        Get(p => p.WareHouseID == WareHouseID)
                        .Select(c => new DropDownDto
                        {
                            DrId = c.ProductLocationID,
                            DrName = c.ProductLocationAddress
                        }).ToList();
        
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = productLocationList
            };
        }
    }
}