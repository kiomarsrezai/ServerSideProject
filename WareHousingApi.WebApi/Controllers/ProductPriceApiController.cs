using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductPriceApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IProductPriceRepository _price;

        public ProductPriceApiController(IUnitOfWork context, IProductPriceRepository price)
        {
            _context = context;
            _price = price;
        }

        [HttpGet("GetProductPrice")]
        public ApiResponse<IEnumerable<ProductPriceList>> Get()
        {
            var priceList = _price.GetProductPriceList();
            return new ApiResponse<IEnumerable<ProductPriceList>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = priceList
            };
        }

        [HttpGet("GetProductPriceHistory")]
        public ApiResponse<IEnumerable<ProductPrices_Tbl>> GetProductPriceHistory(int ProductID)
        {
            var getPriceHistory = _context.productPriceUW.Get(pp => pp.ProductID == ProductID);
            return new ApiResponse<IEnumerable<ProductPrices_Tbl>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = getPriceHistory
            };
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductPrices_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<ProductPrices_Tbl> GetById([FromQuery] int productpriceid)
        {
            var productPrice = _context.productPriceUW.GetById(productpriceid);
            return new ApiResponse<ProductPrices_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = productPrice
            };
        }

        [HttpPost]
        [Route("CreateProductPriceApi")]
        public ApiResponse Create([FromForm] ProductPriceCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
                };

            //کنترل اینکه تاریخ اعمال 2 قیمت در یک روز نباشد.
            //قیمت هر کالا در هر روز فقط یک بار مجاز به تغییر می باشد.
            DateTime ActionDateMiladi = ConvertDate.ConvertShamsiToMiladi(model.ActionDate);

            var getProductPrice = _context.productPriceUW.Get(p => p.ProductID == model.ProductID &&
                                                                   p.ActionDate >= ActionDateMiladi);

            if (getProductPrice.Count() > 0)
            {
                //اگر 550 برگردانده شد یعنی تاریخ اعمال کالا بزرگترین تاریخ اعمال نیست.
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DuplicateInformation,
                    Message = ApiResultStatusCode.DuplicateInformation.DisplayNameAttribute(DisplayProperty.Name)
                };
            }

            try
            {
                ProductPrices_Tbl PP = new ProductPrices_Tbl
                {
                    CoverPrice = model.CoverPrice,
                    PurchasePrice = model.PurchasePrice,
                    SalesPrice = model.SalesPrice,
                    CreateDateTime = DateTime.Now,
                    UserID = model.UserID,
                    ProductID = model.ProductID,
                    FiscalYearID = model.FiscalYearID,
                    ActionDate = ActionDateMiladi
                };
                _context.productPriceUW.Create(PP);
                _context.Save();
                return new ApiResponse<ProductPrices_Tbl>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = PP
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

        [HttpDelete]
        [Route("DeletePrice")]
        public ApiResponse DeletePrice(int ProductPriceID)
        {
            if (ProductPriceID == 0)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ServerError,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            var query = _context.productPriceUW.GetById(ProductPriceID);
            if (DateTime.Now.Date < query.ActionDate)
            {
                _context.productPriceUW.DeleteById(ProductPriceID);
                _context.Save();
                return new ApiResponse
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            else
            {
                return new ApiResponse
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.DateTimeError,
                    Message = ApiResultStatusCode.DateTimeError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
        }
    }
}