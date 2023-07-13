using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

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
        public ApiResult<IEnumerable<ProductLocations_Tbl>> GetProductLocation([FromBody] int wareHouseID)
        {
            var productLocationList = _context.productLocationUW.Get(pl => pl.WareHouseID == wareHouseID);
            return Ok(productLocationList);
        }

        [HttpPost]
        [Route("CreateLocationApi")]
        public ApiResult<string> Create([FromForm] ProductLocationCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (model.ProductLocationAddress == "") return BadRequest(model.ProductLocationAddress);
            //کنترل تکراری نبودن اطلاعات
            var getLocation = _context.productLocationUW.Get(pl => pl.ProductLocationAddress == model.ProductLocationAddress && pl.WareHouseID == model.WareHouseID);
            if (getLocation.Count() > 0)
            {
                //تکراری
                return BadRequest(getLocation);
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
                return Ok(PL);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductLocations_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<ProductLocations_Tbl> GetById([FromQuery] int productlocationid)
        {
            var plocation = _context.productLocationUW.GetById(productlocationid);
            return Ok(plocation);
        }

        [HttpPut]
        [Route("UpdateProductLocation")]
        [ProducesResponseType(typeof(ProductLocations_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> Update([FromForm] ProductLocationEditModel model)
        {
            if (model.ProductLocationID == 0) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            //کنترل تکراری بودن
            var getPlocation = _context.productLocationUW.Get(p => p.ProductLocationAddress == model.ProductLocationAddressE && p.WareHouseID == model.WareHouseIDE);
            if (getPlocation.Count() > 0)
            {
                return BadRequest();
            }

            return Ok(_location.UpdateProductLocation(model));
        }

        [HttpGet("ProductLocationListDropDown")]
        public ApiResult<string> ProductLocationList(int WareHouseID)
        {
            IEnumerable<DropDownDto> productLocationList = _context.productLocationUW.
                        Get(p => p.WareHouseID == WareHouseID)
                        .Select(c => new DropDownDto
                        {
                            DrId = c.ProductLocationID,
                            DrName = c.ProductLocationAddress
                        }).ToList();

            return Ok(productLocationList);
        }
    }
}