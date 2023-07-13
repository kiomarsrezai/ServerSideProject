using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WareHouseApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IWareHouseRepository _ware;

        public WareHouseApiController(IUnitOfWork context, IWareHouseRepository ware)
        {
            _context = context;
            _ware = ware;
        }


        [HttpGet("GetWareHouse")]
        public ApiResult<IEnumerable<WareHouses_Tbl>> Get()
        {
            var wareHouseList = _context.wareHouseUW.Get();
            return Ok(wareHouseList);
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WareHouses_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<WareHouses_Tbl> GetById([FromQuery] int wareHouseid)
        {
            var wareHouse = _context.wareHouseUW.GetById(wareHouseid);
            return Ok(wareHouse);
            //return wareHouse == null ? NotFound() : Ok(wareHouse);
        }

        [HttpPost]
        [Route("CreateWareHouseApi")]
        public ApiResult<string> Create([FromForm] WareHouseCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return BadRequest();
            //کنترل تکراری نبودن اطلاعات
            var getWareHouse = _context.wareHouseUW.Get(p => p.WareHouseName == model.WareHouseName);
            if (getWareHouse.Count() > 0)
            {
                //تکراری
                return BadRequest();
            }
            try
            {
                WareHouses_Tbl WH = new WareHouses_Tbl
                {
                    CreateDateTime = DateTime.Now,
                    UserID = model.UserID,
                    WareHouseName = model.WareHouseName,
                    WareHouseAddress = model.WareHouseAddress,
                    WareHouseTel = model.WareHouseTel
                };
                _context.wareHouseUW.Create(WH);
                _context.Save();
                return Ok(WH);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdateWareHouse")]
        //[ProducesResponseType(typeof(WareHouses_Tbl), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> Update([FromForm] WareHouseEditModel model)
        {
            if (model.WareHouseID == 0) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();
            //Update
            //_ware.UpdateWareHouse(model)
            return Ok(_ware.UpdateWareHouse(model));
        }

        [HttpGet("WareHouseListDropDown")]
        public ApiResult<IEnumerable<DropDownDto>> WareHouseListDropDown()
        {
            IEnumerable<DropDownDto> WareHouseList = _context.wareHouseUW.Get().Select(c => new DropDownDto
            {
                DrId = c.WareHouseID,
                DrName = c.WareHouseName
            });
            return Ok(WareHouseList);
        }

        [HttpGet("WareHouseUserOrientedListDropDownApi")]
        public ApiResult<IEnumerable<DropDownDto>> WareHouseUserOrientedListDropDown(string UserID)
        {
            //لیست آیدی انبارهایی که کاربر دسترسی دارد
            var getUserWareHouseID = _context.userInWareHouseUW.Get(u => u.UserIDInWareHouse == UserID)
                .Select(s => s.WareHouseID);

            IEnumerable<DropDownDto> WareHouseList = _context.wareHouseUW.Get(w => getUserWareHouseID.Contains(w.WareHouseID)).
                Select(c => new DropDownDto
                {
                    DrId = c.WareHouseID,
                    DrName = c.WareHouseName
                });
            return Ok(WareHouseList);
        }
    }
}