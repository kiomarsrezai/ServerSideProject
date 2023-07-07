using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebFramework.StandardApiResult;

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
        public ApiResponse<IEnumerable<Products_Tbl>> Get()
        {
            var productList = _context.productUW.Get(null, "Supplier,Country");
            return new ApiResponse<IEnumerable<Products_Tbl>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = productList
            };
        }


        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Products_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<Products_Tbl> GetById([FromQuery] int productid)
        {
            var product = _context.productUW.GetById(productid);
            return new ApiResponse<Products_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = product
            };
        }

        [HttpPost]
        [Route("CreateProductApi")]
        public ApiResponse Create([FromForm] ProductCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
                };
            //کنترل تکراری نبودن اطلاعات
            var getProduct = _context.productUW.Get(p => p.ProductName == model.ProductName || p.ProductCode == model.ProductCode);
            if (getProduct.Count() > 0)
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
                return new ApiResponse<Products_Tbl>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = P
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

        [HttpPut("{id}")]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(Products_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromForm] ProductEditModel model)
        {
            if (model.ProductID == 0) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
                };
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
            return new ApiResponse<Products_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = getProduct
            };
        }

        [HttpGet("ProductListDropDown")]
        public ApiResponse<IEnumerable<DropDownDto>> ProductListDropDown()
        {
            IEnumerable<DropDownDto> ProductList = _context.productUW.Get().Select(c => new DropDownDto
            {
                DrId = c.ProductID,
                DrName = c.ProductName
            });
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = ProductList
            };
        }

        //[FromForm] : Gets Values from posted form fields
        //[fromBody] : Gets Values from the request body

        //[FromForm] : Gets Values from posted form fields
        //[fromBody] : Gets Values from the request body
    }
}
