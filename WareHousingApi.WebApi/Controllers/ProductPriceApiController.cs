using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

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
        public ApiResult<IEnumerable<ProductPriceList>> Get()
        {
            var priceList = _price.GetProductPriceList();
            return Ok(priceList);
        }

        [HttpGet("GetProductPriceHistory")]
        public ApiResult<IEnumerable<ProductPrices_Tbl>> GetProductPriceHistory(int ProductID)
        {
            var getPriceHistory = _context.productPriceUW.Get(pp => pp.ProductID == ProductID);
            return Ok(getPriceHistory);
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductPrices_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<ProductPrices_Tbl> GetById([FromQuery] int productpriceid)
        {
            var productPrice = _context.productPriceUW.GetById(productpriceid);
            return Ok(productPrice);
        }

        [HttpPost]
        [Route("CreateProductPriceApi")]
        public ApiResult<string> Create([FromForm] ProductPriceCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return BadRequest("پارامتر نامعتبر");

            //کنترل اینکه تاریخ اعمال 2 قیمت در یک روز نباشد.
            //قیمت هر کالا در هر روز فقط یک بار مجاز به تغییر می باشد.
            DateTime ActionDateMiladi = ConvertDate.ConvertShamsiToMiladi(model.ActionDate);

            var getProductPrice = _context.productPriceUW.Get(p => p.ProductID == model.ProductID &&
                                                                   p.ActionDate >= ActionDateMiladi);

            if (getProductPrice.Count() > 0)
            {
                //اگر 550 برگردانده شد یعنی تاریخ اعمال کالا بزرگترین تاریخ اعمال نیست.
                return BadRequest();
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
                return Ok(PP);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeletePrice")]
        public ApiResult DeletePrice(int ProductPriceID)
        {
            if (ProductPriceID == 0)
            {
                return BadRequest();
            }
            var query = _context.productPriceUW.GetById(ProductPriceID);
            if (DateTime.Now.Date < query.ActionDate)
            {
                _context.productPriceUW.DeleteById(ProductPriceID);
                _context.Save();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}