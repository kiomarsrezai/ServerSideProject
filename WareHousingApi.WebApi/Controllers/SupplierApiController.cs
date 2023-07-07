using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public SupplierApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetSupplier")]
        public ApiResponse<IEnumerable<Suppliers_Tbl>> Get()
        {
            var supplier = _context.supplierUW.Get();
            return new ApiResponse<IEnumerable<Suppliers_Tbl>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = supplier
            };
        }


        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Suppliers_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<Suppliers_Tbl> GetById([FromQuery] int supplierid)
        {
            var supplier = _context.supplierUW.GetById(supplierid);
            //return supplier == null ? NotFound() : Ok(supplier);
            return new ApiResponse<Suppliers_Tbl>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = supplier
            };
        }

        [HttpPost]
        [Route("CreateSupplierApi")]
        public ApiResponse Create([FromForm] SupplierCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                //return BadRequest(model);
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.BadRequest,
                };

            //کنترل تکراری نبودن اطلاعات
            var getSupplier = _context.supplierUW.Get(c => c.SupplierName == model.SupplierName || c.SupplierTel == model.SupplierTel);
            if (getSupplier.Count() > 0)
            {
                //تکراری
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.DuplicateInformation.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.DuplicateInformation,
                };
            }
            try
            {
                Suppliers_Tbl S = new Suppliers_Tbl
                {
                    SupplierName = model.SupplierName,
                    SupplierTel = model.SupplierTel,
                    Website = model.Website,
                    CreateDateTime = DateTime.Now,
                    UserID = model.UserID
                };
                _context.supplierUW.Create(S);
                _context.Save();
                return new ApiResponse<Suppliers_Tbl>
                {
                    flag = true,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.Success,
                    Data = S
                };
            }
            catch (Exception)
            {
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.ServerError.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.ServerError,
                };
            }
        }

        [HttpPut("{id}")]
        [Route("UpdateSupplier")]
        [ProducesResponseType(typeof(Suppliers_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse Update([FromBody] SupplierEditModel model)
        {
            if (model.SupplierID == 0) return new ApiResponse
            {
                flag = false,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.BadRequest,
            };

            if (!ModelState.IsValid)
                return new ApiResponse
                {
                    flag = false,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                    StatusCode = ApiResultStatusCode.BadRequest,
                };

            var getSupplier = _context.supplierUW.GetById(model.SupplierID);
            if (getSupplier != null)
            {
                getSupplier.SupplierName = model.SupplierName;
                getSupplier.SupplierTel = model.SupplierTel;
                getSupplier.SupplierID = model.SupplierID;
                getSupplier.Website = model.Website;
            }

            _context.supplierUW.Update(getSupplier);
            _context.Save();
            return new ApiResponse<Suppliers_Tbl>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = getSupplier
            };
        }

        [HttpGet("SupplierListDropDown")]
        public ApiResponse SupplierListDropDown()
        {
            IEnumerable<DropDownDto> supplierList = _context.supplierUW.Get().Select(c => new DropDownDto
            {
                DrId = c.SupplierID,
                DrName = c.SupplierName
            });


            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = supplierList
            };
            //return Ok(JsonConvert.SerializeObject(supplierList));
        }
    }
}