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
        public ApiResult<IEnumerable<FiscalYears_Tbl>> Get()
        {
            var fiscalYearList = _context.fiscalYearUW.Get();
            return Ok(fiscalYearList.OrderByDescending(o => o.FiscalYearID));
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(FiscalYears_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> GetById([FromQuery] int fiscalyearid)
        {
            var fiscalyear = _context.fiscalYearUW.GetById(fiscalyearid);
            return Ok(fiscalyear);
        }

        [HttpPost]
        [Route("CreateFiscalYearApi")]
        public ApiResult<string> Create([FromForm] FiscalYearCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //return BadRequest(model);
            //کنترل تکراری نبودن اطلاعات
            var getFiscal = _context.fiscalYearUW.Get(p => p.FiscalYearDescription == model.FiscalYearDescription);
            if (getFiscal.Count() > 0)
            {
                //تکراری
                return BadRequest(model.FiscalYearDescription);
            }
            //کنترل تاریخ
            bool checkDate = _fiscal.CheckDateForFiscalYear(ConvertDate.ConvertShamsiToMiladi(model.StartDate)
                                                            , ConvertDate.ConvertShamsiToMiladi(model.EndDate));

            if (checkDate == false)
            {
                return BadRequest("پارامتر نامعتبر");
            }
            try
            {
                FiscalYears_Tbl FY = new FiscalYears_Tbl
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
                return Ok(FY);
            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }


        [HttpPut]
        [Route("UpdateFiscalYear")]
        [ProducesResponseType(typeof(FiscalYears_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> Update([FromForm] FiscalYearEditModel model)
        {
            if (model.FiscalYearID == 0) return BadRequest("پارامتر نامعتبر");

            if (!ModelState.IsValid)
                return BadRequest("پارامتر نامعتبر");

            //کنترل تاریخ
            bool checkDate = _fiscal.CheckDateForFiscalYear(ConvertDate.ConvertShamsiToMiladi(model.StartDateE)
                                                            , ConvertDate.ConvertShamsiToMiladi(model.EndDateE));

            if (checkDate == false)
            {
                return BadRequest("پارامتر نامعتبر");
            }
            //Update
            //return Ok();
            return Ok(model);
        }

        [HttpGet("FiscalYearListDropDown"), AllowAnonymous]
        public ApiResult<IEnumerable<DropDownDto>> FiscalYearListDropDown()
        {
            IEnumerable<DropDownDto> FiscalList = _context.fiscalYearUW.Get().Select(c => new DropDownDto
            {
                DrId = c.FiscalYearID,
                DrName = c.FiscalYearDescription
            });
            //string fiscalResult = JsonConvert.SerializeObject(FiscalList);

            return Ok(FiscalList.OrderByDescending(o => o.DrId));
        }

        //دریافت اطلاعات سال مالی کنونی و باز
        [HttpGet("GetCurrentFiscalYearApi")]
        public ApiResult<FiscalYears_Tbl> GetCurrentFiscalYear()
        {
            return Ok(_context.fiscalYearUW.Get(f => f.FiscalFlag == true).Single());
        }
        //دریافت اطلاعات سال مالی جدید
        [HttpGet("GetNewFiscalYearApi")]
        public ApiResult<FiscalYears_Tbl> GetNewFiscalYear()
        {
            DateTime LastEndDate = (_context.fiscalYearUW.Get(f1 => f1.FiscalFlag == true).Select(s => s.EndDate.Date)).Single();

            return Ok(_context.fiscalYearUW.Get(f => f.FiscalFlag == false && f.StartDate.Date > LastEndDate).Single());
        }

        //بستن سال مالی
        [HttpPost]
        [Route("TransferToNewFiscalYear")]
        public ApiResult TransferToNewFiscalYear(CloseFiscalModel model)
        {
            try
            {
                _inventory.TransferToNewFiscalYearRepo(model);
                return BadRequest("پارامتر نامعتبر");
            }
            catch
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }
    }
}