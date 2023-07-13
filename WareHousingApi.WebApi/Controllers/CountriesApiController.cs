using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WareHousingApi.Common.Api;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Models;

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
        public ApiResult<IEnumerable<Countries_Tbl>> Get()
        {
            var countryList = _context.countryUW.Get();
            //List<string> message =new List<string> { "لیست کشورها"};
            //ApiResult rse =new (true, ApiResultStatusCode.Success, message, true);

            return Ok(countryList);
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
        public ApiResult<Countries_Tbl> GetById([FromQuery]int countryid)
        {
            var country = _context.countryUW.GetById(countryid);

            if (country == null) return BadRequest("پارمتر نامعتبر");

            return Ok(country);
        }

        [HttpPost]
        [Route("CreateCountryApi")]
        public ApiResult<Countries_Tbl> Create([FromForm] string countryname = "", [FromForm] string userid = "")
        {
            //کنترل نال بودن اطلاعات
            if (countryname == "") return BadRequest("پارمتر نامعتبر");
            //کنترل تکراری نبودن اطلاعات
            var getCountry = _context.countryUW.Get(c => c.CountryName == countryname);
            if (getCountry.Count() > 0)
            {
                //تکراری
                return BadRequest("پارمتر نامعتبر");
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
                return Ok(C);
            }
            catch (Exception)
            {
                return BadRequest("پارمتر نامعتبر");
            }
        }

        [HttpPut]
        [Route("UpdateCountry")]
        //[ProducesResponseType(typeof(Countries_Tbl), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<Countries_Tbl> Update([FromBody] CountryEditViewModel model)
        {
            if (model.CountryID == 0) return BadRequest("پارمتر نامعتبر");

            var getCountry = _context.countryUW.GetById(model.CountryID);
            if (getCountry != null)
            {
                getCountry.CountryName = model.CountryName;
            }

            _context.countryUW.Update(getCountry);
            _context.Save();
            return Ok(getCountry);
        }

        [HttpGet("CountryListDropDown")]
        public ApiResult<DropDownDto> CountryListDropDown()
        {
            IEnumerable<DropDownDto> countryList = _context.countryUW.Get().Select(c => new DropDownDto
            {
                DrId = c.CountryID,
                DrName = c.CountryName
            });

            return Ok(countryList);

        }

    }
}