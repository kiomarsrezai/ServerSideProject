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
    public class RialiStockApiController : ControllerBase
    {
        private readonly IRialiStockRepository _rial;
        public RialiStockApiController(IRialiStockRepository rial)
        {
            _rial = rial;
        }


        //متدی که لیست موجودی تعدادی و ریالی هر کالا در هر انبار
        [HttpGet("GetRialiStockApi")]
        public ApiResult<IEnumerable<RialiStockDto>> GetRialiStock([FromBody] RialiStockArguman model)
        {
            return Ok(_rial.GetRialiStock(model.FiscalYearID, model.WareHouseID));
        }
    }
}
