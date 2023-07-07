using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
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
        public ApiResponse<IEnumerable<WareHouses_Tbl>> Get()
        {
            var wareHouseList = _context.wareHouseUW.Get();
            return new ApiResponse<IEnumerable<WareHouses_Tbl>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = wareHouseList
            };
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WareHouses_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<WareHouses_Tbl> GetById([FromQuery] int wareHouseid)
        {
            var wareHouse = _context.wareHouseUW.GetById(wareHouseid);
            return new ApiResponse<WareHouses_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = wareHouse
            };
            //return wareHouse == null ? NotFound() : Ok(wareHouse);
        }

        [HttpPost]
        [Route("CreateWareHouseApi")]
        public ApiResponse Create([FromForm] WareHouseCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
                };
            //کنترل تکراری نبودن اطلاعات
            var getWareHouse = _context.wareHouseUW.Get(p => p.WareHouseName == model.WareHouseName);
            if (getWareHouse.Count() > 0)
            {
                //تکراری
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.DuplicateInformation,
                    Message = ApiResultStatusCode.DuplicateInformation.DisplayNameAttribute(DisplayProperty.Name)
                };
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
                return new ApiResponse<WareHouses_Tbl>
                {
                    flag = true,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.Success,
                    Data = WH
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


        [HttpPut("{id}")]
        [Route("UpdateWareHouse")]
        [ProducesResponseType(typeof(WareHouses_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromForm] WareHouseEditModel model)
        {
            if (model.WareHouseID == 0) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
                };

            //Update
            //_ware.UpdateWareHouse(model)
            return new ApiResponse<WareHouses_Tbl>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = _ware.UpdateWareHouse(model)
            };
        }

        [HttpGet("WareHouseListDropDown")]
        public ApiResponse<IEnumerable<DropDownDto>> WareHouseListDropDown()
        {
            IEnumerable<DropDownDto> WareHouseList = _context.wareHouseUW.Get().Select(c => new DropDownDto
            {
                DrId = c.WareHouseID,
                DrName = c.WareHouseName
            });
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = WareHouseList
            };
        }

        [HttpGet("WareHouseUserOrientedListDropDownApi")]
        public ApiResponse<IEnumerable<DropDownDto>> WareHouseUserOrientedListDropDown(string UserID)
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
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = WareHouseList
            };
        }
    }
}