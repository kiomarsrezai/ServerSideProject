using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Models;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public CountriesApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetCountry")]
        public ApiResponse<IEnumerable<Countries_Tbl>> Get()
        {
            var countryList = _context.countryUW.Get();
            return new ApiResponse<IEnumerable<Countries_Tbl>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = countryList
            };
        }


        //[HttpGet("GetByIdquery")]
        //public IActionResult GetByIdquery([FromQuery]int id, [FromQuery]string name)
        //{
        //    return Ok($"id = {id}{name}");
        //}

        //[HttpGet]
        //[Route("GetByIdRoute/{id}/{name}")]
        //public IActionResult GetByIdRoute([FromRoute] int id, [FromRoute] string name)
        //{
        //    return Ok($"id = {id}{name}");
        //}

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Countries_Tbl) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse GetById([FromQuery]int countryid)
        {
            var country = _context.countryUW.GetById(countryid);

            if (country == null) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.NotFound,
                Message = ApiResultStatusCode.NotFound.DisplayNameAttribute(DisplayProperty.Name)
            };
            
            return new ApiResponse<Countries_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = country
            };
        }

        [HttpPost]
        [Route("CreateCountryApi")]
        public ApiResponse Create([FromForm] string countryname = "", [FromForm] string userid = "")
        {
            //کنترل نال بودن اطلاعات
            if (countryname == "") return  new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };
            //کنترل تکراری نبودن اطلاعات
            var getCountry = _context.countryUW.Get(c => c.CountryName == countryname);
            if (getCountry.Count() > 0)
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
                Countries_Tbl C = new Countries_Tbl
                {
                    CountryName = countryname,
                    CreateDateTime = DateTime.Now,
                    UserID = userid
                };
                _context.countryUW.Create(C);
                _context.Save();
                return new ApiResponse<Countries_Tbl>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = C
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
        [Route("UpdateCountry")]
        [ProducesResponseType(typeof(Countries_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromBody] CountryEditViewModel model)
        {
            if (model.CountryID == 0) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            var getCountry = _context.countryUW.GetById(model.CountryID);
            if (getCountry != null)
            {
                getCountry.CountryName = model.CountryName;
            }

            _context.countryUW.Update(getCountry);
            _context.Save();
            return new ApiResponse<Countries_Tbl>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = getCountry
            };
        }

        [HttpGet("CountryListDropDown")]
        public ApiResponse CountryListDropDown()
        {
            IEnumerable<DropDownDto> countryList = _context.countryUW.Get().Select(c => new DropDownDto
            {
                DrId = c.CountryID,
                DrName = c.CountryName
            });

            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = countryList
            };

        }

    }
}