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
    public class ProductsApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProductsApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetProduct")]
        public ApiResult<IEnumerable<Products_Tbl>> Get()
        {
            var productList = _context.productUW.Get(null, "Supplier,Country");
            return Ok(productList);
        }


        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Products_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<Products_Tbl> GetById([FromQuery] int productid)
        {
            var product = _context.productUW.GetById(productid);
            return Ok(product);
        }

        [HttpPost]
        [Route("CreateProductApi")]
        public ApiResult<string> Create([FromForm] ProductCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return BadRequest();
            //کنترل تکراری نبودن اطلاعات
            var getProduct = _context.productUW.Get(p => p.ProductName == model.ProductName || p.ProductCode == model.ProductCode);
            if (getProduct.Count() > 0)
            {
                //تکراری
                return BadRequest();
            }
            try
            {
                Products_Tbl P = new Products_Tbl
                {
                    ProductName = model.ProductName,
                    ProductCode = model.ProductCode,
                    //ProductImage = Path.GetFileName(model.ProductImage),
                    ProductImage = model.ProductImage,
                    CountInPacking = model.CountInPacking,
                    CountryID = model.CountryID,
                    SupplierID = model.SupplierID,
                    ProductWeight = model.ProductWeight,
                    IsRefregerator = model.IsRefregerator,
                    PackingType = model.PackingType,
                    CreateDateTime = DateTime.Now,
                    UserID = model.UserID
                };
                _context.productUW.Create(P);
                _context.Save();
                return Ok(P);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(Products_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> Update([FromForm] ProductEditModel model)
        {
            if (model.ProductID == 0) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();
            //کنترل تکراری بودن
            var getProduct = _context.productUW.GetById(model.ProductID);
            if (getProduct != null)
            {
                getProduct.ProductName = model.ProductNameE;
                getProduct.ProductCode = model.ProductCodeE;
                getProduct.ProductImage = model.ProductImageE;
                getProduct.CountInPacking = model.CountInPackingE;
                getProduct.CountryID = model.CountryIDE;
                getProduct.SupplierID = model.SupplierIDE;
                getProduct.ProductWeight = model.ProductWeightE;
                getProduct.IsRefregerator = model.IsRefregeratorE;
                getProduct.PackingType = model.PackingTypeE;
            }

            _context.productUW.Update(getProduct);
            _context.Save();
            return Ok(getProduct);
        }

        [HttpGet("ProductListDropDown")]
        public ApiResult<IEnumerable<DropDownDto>> ProductListDropDown()
        {
            IEnumerable<DropDownDto> ProductList = _context.productUW.Get().Select(c => new DropDownDto
            {
                DrId = c.ProductID,
                DrName = c.ProductName
            });
            return Ok(ProductList);
        }

        //[FromForm] : Gets Values from posted form fields
        //[fromBody] : Gets Values from the request body

        //[FromForm] : Gets Values from posted form fields
        //[fromBody] : Gets Values from the request body
    }
}
