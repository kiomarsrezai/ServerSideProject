using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Models.Dto;
using WareHousingApi.WebFramework.StandardApiResult;

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
        public ApiResponse<IEnumerable<RialiStockDto>> GetRialiStock([FromBody] RialiStockArguman model)
        {
            return new ApiResponse<IEnumerable<RialiStockDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = _rial.GetRialiStock(model.FiscalYearID, model.WareHouseID)
            };
        }
    }
}
