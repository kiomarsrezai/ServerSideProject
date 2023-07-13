using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.Api;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public CustomerApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetCustomer")]
        public ApiResult<IEnumerable<Customers_Tbl>> Get(string userID)
        {
            var customerList = _context.customerUW.Get(c => c.UserID == userID, "WareHouses");
            return Ok(customerList);
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customers_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> GetById([FromQuery] int customerid)
        {
            var customer = _context.customerUW.GetById(customerid);

            if (customer == null) return BadRequest("پارامتر نامعتبر");

            return Ok(customer);
        }

        [HttpPost]
        [Route("CreateCustomerApi")]
        public ApiResult<string> Create([FromForm] CreateCustomerViewModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");
            //کنترل تکراری نبودن اطلاعات
            var getCustomer = _context.customerUW.Get(c => c.CustomerFullName == model.CustomerFullName && c.CustomerTel == model.CustomerTel);
            if (getCustomer.Count() > 0)
            {
                //تکراری
                return BadRequest("پارامتر نامعتبر");
            }
            try
            {
                Customers_Tbl C = new Customers_Tbl
                {
                    CustomerFullName = model.CustomerFullName,
                    CustomerTel = model.CustomerTel,
                    EconomicCode = model.EconomicCode,
                    CustomerAddress = model.CustomerAddress,
                    UserID = model.UserID,
                    WareHouseID = model.WareHouseID,
                    CreateDateTime = DateTime.Now
                };
                _context.customerUW.Create(C);
                _context.Save();
                return Ok(C);
            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        //[ProducesResponseType(typeof(Customers_Tbl), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<Customers_Tbl> Update([FromForm] EditCustomerViewModel model)
        {
            if (model.CustomerID == 0) return BadRequest("پارامتر نامعتبر");

            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");

            var getCustomer = _context.customerUW.GetById(model.CustomerID);
            if (getCustomer != null)
            {
                getCustomer.CustomerFullName = model.CustomerFullNameE;
                getCustomer.CustomerTel = model.CustomerTelE;
                getCustomer.WareHouseID = model.WareHouseIDE;
                getCustomer.EconomicCode = model.EconomicCodeE;
                getCustomer.CustomerAddress = model.CustomerAddressE;
            }

            _context.customerUW.Update(getCustomer);
            _context.Save();
            return Ok(getCustomer);
        }

        [HttpGet("CustomerListDropDown")]
        public ApiResult<IEnumerable<DropDownDto>> CustomerListDropDown(int warehouseid)
        {
            IEnumerable<DropDownDto> customerList = _context.customerUW
                                .Get(c => c.WareHouseID == warehouseid).Select(c => new DropDownDto
                                {
                                    DrId = c.CustomerID,
                                    DrName = c.CustomerFullName
                                });

            return Ok(customerList);

        }
    }
}
