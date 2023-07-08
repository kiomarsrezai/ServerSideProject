using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebApi.Tools;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FiscalYearApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IFiscalYearRepository _fiscal;
        private readonly IInventoryRepository _inventory;

        public FiscalYearApiController(IUnitOfWork context, IFiscalYearRepository fiscal, IInventoryRepository inventory)
        {
            _context = context;
            _fiscal = fiscal;
            _inventory = inventory;
        }

        [HttpGet("GetFiscalYear")]
        public ApiResponse<IEnumerable<FiscalYear>> Get()
        {
            var fiscalYearList = _context.fiscalYearUW.Get();
            return new ApiResponse<IEnumerable<FiscalYear>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = fiscalYearList.OrderByDescending(o => o.FiscalYearID)
            };
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FiscalYear), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<FiscalYear> GetById([FromQuery] int fiscalyearid)
        {
            var fiscalyear = _context.fiscalYearUW.GetById(fiscalyearid);
            return new ApiResponse<FiscalYear>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = fiscalyear
            };
        }

        [HttpPost]
        [Route("CreateFiscalYearApi")]
        public ApiResponse Create([FromForm] FiscalYearCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.BadRequest
                };
            //return BadRequest(model);
            //کنترل تکراری نبودن اطلاعات
            var getFiscal = _context.fiscalYearUW.Get(p => p.FiscalYearDescription == model.FiscalYearDescription);
            if (getFiscal.Count() > 0)
            {
                //تکراری
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DuplicateInformation,
                    Message = ApiResultStatusCode.DuplicateInformation.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            //کنترل تاریخ
            bool checkDate = _fiscal.CheckDateForFiscalYear(ConvertDate.ConvertShamsiToMiladi(model.StartDate)
                                                            , ConvertDate.ConvertShamsiToMiladi(model.EndDate));

            if (checkDate == false)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DateTimeError,
                    Message = ApiResultStatusCode.DateTimeError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            try
            {
                FiscalYear FY = new FiscalYear
                {
                    CreateDateTime = DateTime.Now,
                    FiscalFlag = false,
                    //
                    UserID = model.UserID,
                    //
                    StartDate = ConvertDate.ConvertShamsiToMiladi(model.StartDate),
                    EndDate = ConvertDate.ConvertShamsiToMiladi(model.EndDate),
                    FiscalYearDescription = model.FiscalYearDescription
                };
                _context.fiscalYearUW.Create(FY);
                _context.Save();
                return new ApiResponse<FiscalYear>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = FY
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.ServerError
                };
            }
        }


        [HttpPut("{id}")]
        [Route("UpdateFiscalYear")]
        [ProducesResponseType(typeof(FiscalYear), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromForm] FiscalYearEditModel model)
        {
            if (model.FiscalYearID == 0) return new ApiResponse
            {
                flag = false,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.BadRequest
            };

            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.BadRequest
                };

            //کنترل تاریخ
            bool checkDate = _fiscal.CheckDateForFiscalYear(ConvertDate.ConvertShamsiToMiladi(model.StartDateE)
                                                            , ConvertDate.ConvertShamsiToMiladi(model.EndDateE));

            if (checkDate == false)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DateTimeError,
                    Message = ApiResultStatusCode.DateTimeError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            //Update
            //return Ok();
            return new ApiResponse<FiscalYear>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = _fiscal.UpdateFiscalYear(model)
            };
        }

        [HttpGet("FiscalYearListDropDown"), AllowAnonymous]
        public ApiResponse FiscalYearListDropDown()
        {
            IEnumerable<DropDownDto> FiscalList = _context.fiscalYearUW.Get().Select(c => new DropDownDto
            {
                DrId = c.FiscalYearID,
                DrName = c.FiscalYearDescription
            });
            //string fiscalResult = JsonConvert.SerializeObject(FiscalList);

            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = FiscalList.OrderByDescending(o => o.DrId)
            };
        }

        //دریافت اطلاعات سال مالی کنونی و باز
        [HttpGet("GetCurrentFiscalYearApi")]
        public ApiResponse<FiscalYear> GetCurrentFiscalYear()
        {
            return new ApiResponse<FiscalYear>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = _context.fiscalYearUW.Get(f => f.FiscalFlag == true).Single()
            };
        }
        //دریافت اطلاعات سال مالی جدید
        [HttpGet("GetNewFiscalYearApi")]
        public ApiResponse<FiscalYear> GetNewFiscalYear()
        {
            DateTime LastEndDate = (_context.fiscalYearUW.Get(f1 => f1.FiscalFlag == true).Select(s => s.EndDate.Date)).Single();

            return new ApiResponse<FiscalYear>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = _context.fiscalYearUW.Get(f => f.FiscalFlag == false && f.StartDate.Date > LastEndDate).Single()
            };
        }

        //بستن سال مالی
        [HttpPost]
        [Route("TransferToNewFiscalYear")]
        public ApiResponse TransferToNewFiscalYear(CloseFiscalModel model)
        {
            try
            {
                _inventory.TransferToNewFiscalYearRepo(model);
                return new ApiResponse
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
            catch
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ServerError,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name)
                };
            }
        }
    }
}