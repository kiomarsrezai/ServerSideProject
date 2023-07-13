using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WastageRialiStockApiController : ControllerBase
    {
        private readonly IWastageRialiRepository _wrial;

        public WastageRialiStockApiController(IWastageRialiRepository wrial)
        {
            _wrial = wrial;
        }

        //متدی که لیست موجودی تعدادی و ریالی هر کالا در هر انبار
        [HttpGet("GetWastageRialiStockApi")]
        public ApiResult<IEnumerable<WastageRialiStock>> GetWastageRialiStock([FromBody] WastageRialiStockArguman model)
        {
            return Ok(_wrial.GetWastageRialiStock(model.FiscalYearID, model.WareHouseID));
        }

    }
}
