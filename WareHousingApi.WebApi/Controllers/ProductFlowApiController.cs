using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Models.Dto;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductFlowApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProductFlowApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetProductFlowApi")]
        public ApiResponse ProductFlow([FromBody] ProductFlowResponseDto model)
        {
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (model.FromDate == "" || model.FromDate == null)
            {
                model.FromDate = "1300/01/01";
            }
            if (model.ToDate == "" || model.ToDate == null)
            {
                model.ToDate = "1800/01/01";
            }

            return new ApiResponse<IEnumerable<ProductFlowReplyDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = _context.inventoryUW.Get(i => i.WareHouseID == model.WareHouseID &&
                                                   i.FiscalYearID == model.FiscalYearID &&
                                                   i.ProductID == model.ProductID &&
                                                   (i.OperationDate >= ConvertDate.ConvertShamsiToMiladi(model.FromDate) &&
                                                    i.OperationDate <= ConvertDate.ConvertShamsiToMiladi(model.ToDate)), "Users")
                                                    .Select(s => new ProductFlowReplyDto
                                                    {
                                                        Description = s.Description,
                                                        ExpireDate = s.ExpireDate,
                                                        OperationDate = s.OperationDate,
                                                        OpertaionType = s.OperationType,
                                                        ProductCountMain = s.ProductCountMain,
                                                        ProductCountWastage = s.ProductCountWastage,
                                                        UserFullName = s.Users.FirstName + " " + s.Users.Family
                                                    })
            };
        }
    }
}
