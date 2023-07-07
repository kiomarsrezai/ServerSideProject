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
    public class WastageRialiStockApiController : ControllerBase
    {
        private readonly IWastageRialiRepository _wrial;

        public WastageRialiStockApiController(IWastageRialiRepository wrial)
        {
            _wrial = wrial;
        }

        //متدی که لیست موجودی تعدادی و ریالی هر کالا در هر انبار
        [HttpGet("GetWastageRialiStockApi")]
        public ApiResponse<IEnumerable<WastageRialiStock>> GetWastageRialiStock([FromBody] WastageRialiStockArguman model)
        {
            return new ApiResponse<IEnumerable<WastageRialiStock>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = _wrial.GetWastageRialiStock(model.FiscalYearID, model.WareHouseID)
            };
        }

    }
}
