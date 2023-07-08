using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models;
using WareHousingApi.WebFramework.StandardApiResult;

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
        public ApiResponse<IEnumerable<Customer>> Get(string userID)
        {
            var customerList = _context.customerUW.Get(c => c.UserID == userID, "WareHouses");
            return new ApiResponse<IEnumerable<Customer>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = customerList
            };
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse GetById([FromQuery] int customerid)
        {
            var customer = _context.customerUW.GetById(customerid);

            if (customer == null) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.NotFound,
                Message = ApiResultStatusCode.NotFound.DisplayNameAttribute(DisplayProperty.Name)
            };

            return new ApiResponse<Customer>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = customer
            };
        }

        [HttpPost]
        [Route("CreateCustomerApi")]
        public ApiResponse Create([FromForm] CreateCustomerViewModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };
            //کنترل تکراری نبودن اطلاعات
            var getCustomer = _context.customerUW.Get(c => c.CustomerFullName == model.CustomerFullName && c.CustomerTel == model.CustomerTel);
            if (getCustomer.Count() > 0)
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
                Customer C = new Customer
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
                return new ApiResponse<Customer>
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
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromForm] EditCustomerViewModel model)
        {
            if (model.CustomerID == 0) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

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
            return new ApiResponse<Customer>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = getCustomer
            };
        }

        [HttpGet("CustomerListDropDown")]
        public ApiResponse CustomerListDropDown(int warehouseid)
        {
            IEnumerable<DropDownDto> customerList = _context.customerUW
                                .Get(c => c.WareHouseID == warehouseid).Select(c => new DropDownDto
                                {
                                    DrId = c.CustomerID,
                                    DrName = c.CustomerFullName
                                });

            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = customerList
            };

        }
    }
}
