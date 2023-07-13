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
    public class SupplierApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public SupplierApiController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("GetSupplier")]
        public ApiResult<IEnumerable<Suppliers_Tbl>> Get()
        {
            var supplier = _context.supplierUW.Get();
            return Ok(supplier);
        }


        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Suppliers_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<Suppliers_Tbl> GetById([FromQuery] int supplierid)
        {
            var supplier = _context.supplierUW.GetById(supplierid);
            //return supplier == null ? NotFound() : Ok(supplier);
            return Ok(supplier);
        }

        [HttpPost]
        [Route("CreateSupplierApi")]
        public ApiResult<string> Create([FromForm] SupplierCreateModel model)
        {
            //کنترل نال بودن اطلاعات
            if (!ModelState.IsValid)
                //return BadRequest(model);
                return BadRequest();

            //کنترل تکراری نبودن اطلاعات
            var getSupplier = _context.supplierUW.Get(c => c.SupplierName == model.SupplierName || c.SupplierTel == model.SupplierTel);
            if (getSupplier.Count() > 0)
            {
                //تکراری
                return BadRequest("ثبت تکراری");
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
                return Ok(S);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateSupplier")]
        [ProducesResponseType(typeof(Suppliers_Tbl), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResult<string> Update([FromBody] SupplierEditModel model)
        {
            if (model.SupplierID == 0) return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

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
            return Ok(getSupplier);
        }

        [HttpGet("SupplierListDropDown")]
        public ApiResult<string> SupplierListDropDown()
        {
            IEnumerable<DropDownDto> supplierList = _context.supplierUW.Get().Select(c => new DropDownDto
            {
                DrId = c.SupplierID,
                DrName = c.SupplierName
            });


            return Ok(supplierList);
            //return Ok(JsonConvert.SerializeObject(supplierList));
        }
    }
}