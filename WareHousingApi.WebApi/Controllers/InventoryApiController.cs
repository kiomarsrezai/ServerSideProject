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
    public class InventoryApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IInventoryRepository _inventory;

        public InventoryApiController(IUnitOfWork context, IInventoryRepository inventory)
        {
            _context = context;
            _inventory = inventory;
        }

        [HttpGet("GetInventory")]
        public ApiResult<IEnumerable<Inventories_Tbl>> Get()
        {
            var inventoryList = _context.inventoryUW.Get();
            return Ok(inventoryList);
        }

        [HttpGet("GetProductStock")]
        public ApiResult<IEnumerable<InventoryStockModel>> GetProductStock([FromBody] InventoryQueryMaker model)
        {
            var inventoryStockList = _inventory.GetProductStock(model);
            return Ok(inventoryStockList);
        }

        [HttpPost]
        [Route("AddProductStockApi")]
        public async Task<ApiResult<string>> AddProductStock([FromForm] AddStockModel model, CancellationToken ct)
        {
            //حواله ورود به انبار
            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");

            try
            {
                byte OperationTypeVal =
                    (byte)(model.BalanceStockAdd == "on" ? 7 : (model.BalanceStockAdd == "" || model.BalanceStockAdd == null) ? 1 : 0);
                Inventories_Tbl I = new Inventories_Tbl
                {
                    ProductID = model.ProductID,
                    WareHouseID = model.WareHouseID,
                    FiscalYearID = model.FiscalYearID,
                    UserID = model.UserID,
                    CreateDateTime = DateTime.Now,
                    Description = model.Description,
                    OperationType = OperationTypeVal, //ورود به انبار
                    ProductCountMain = model.ProductCountMain,
                    ProductCountWastage = 0,
                    OperationDate = ConvertDate.ConvertShamsiToMiladi(model.OperationDate),
                    ExpireDate = ConvertDate.ConvertShamsiToMiladi(model.ExpireDate),
                    RefferenceID = 0,
                    ProductLocationID = model.ProductLocationID
                };
                await _context.inventoryUW.CreateAsync(I, ct);
                _context.Save();
                return Ok(I);

            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }

        [HttpGet("ProductExpireListDropDown")]
        public ApiResult<string> ProductExpireList(int ProductID, int FiscalYearID, int WareHouseID)
        {
            IList<DropDownDto> expireDateList = _context.inventoryUW.
                        Get(p => p.ProductID == ProductID && p.WareHouseID == WareHouseID && p.FiscalYearID == FiscalYearID
                        && (p.OperationType == 1 || p.OperationType == 9))
                        .OrderBy(o => o.ExpireDate).Select(c => new DropDownDto
                        {
                            DrId = c.InventoryID,
                            DrName = ConvertDate.ConvertMiladiToShamsi(c.ExpireDate, "yyyy/MM/dd")
                        }).ToList();
            //حذف سری ساختهای بدون موجودی
            List<int> ZeroStocks = new List<int>();
            for (int i = 0; i < expireDateList.Count(); i++)
            {
                if (_inventory.GetPhysicalStockForBranch(expireDateList[i].DrId) == 0)
                {
                    ZeroStocks.Add(expireDateList[i].DrId);
                }
            }

            //
            return Ok(expireDateList.Where(e => !ZeroStocks.Contains(e.DrId)).ToList());
        }

        [HttpGet("ProductExpireListBWDropDown")]
        public ApiResult<string> ProductExpireListBW(int ProductID, int FiscalYearID, int WareHouseID)
        {
            //سری ساختهای کالاهای ضایعاتی
            IList<DropDownDto> expireDateList = _context.inventoryUW.
                        Get(p => p.ProductID == ProductID && p.WareHouseID == WareHouseID && p.FiscalYearID == FiscalYearID && p.OperationType == 3)
                        .OrderBy(o => o.ExpireDate).Select(c => new DropDownDto
                        {
                            DrId = c.InventoryID,
                            DrName = ConvertDate.ConvertMiladiToShamsi(c.ExpireDate, "yyyy/MM/dd")
                        }).ToList();
            //حذف سری ساختهای بدون موجودی
            List<int> ZeroStocks = new List<int>();
            for (int i = 0; i < expireDateList.Count(); i++)
            {
                if (_inventory.GetPhysicalWastageStockForBranch(expireDateList[i].DrId) == 0)
                {
                    ZeroStocks.Add(expireDateList[i].DrId);
                }
            }

            //
            return Ok(expireDateList.Where(e => !ZeroStocks.Contains(e.DrId)).ToList());
        }

        [HttpPost]
        [Route("ExitProductStockApi")]
        public async Task<ApiResult<string>> ExitProductStock([FromForm] ExitStockModel model, CancellationToken ct)
        {
            //حواله خروج از انبار
            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");

            if (model.ProductCountMainE > _inventory.GetPhysicalStockForBranch(model.ReffernceInvID))
            {
                return BadRequest("تعداد کالای وارد شده بیشتر از موجودی فیزیکی کالا جهت خروج می باشد.");
            }

            try
            {
                byte OperationTypeVal =
             (byte)(model.BalanceStockRemove == "on" ? 8 : (model.BalanceStockRemove == "" || model.BalanceStockRemove == null) ? 2 : 0);

                var getInfo = _context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvID).Single();
                Inventories_Tbl I = new Inventories_Tbl
                {
                    ProductID = model.ProductIDE,
                    WareHouseID = model.WareHouseIDE,
                    FiscalYearID = model.FiscalYearIDE,
                    UserID = model.UserIDE,
                    CreateDateTime = DateTime.Now,
                    Description = model.DescriptionE,
                    OperationType = OperationTypeVal, //ورود به انبار
                    ProductCountMain = model.ProductCountMainE,
                    ProductCountWastage = 0,
                    OperationDate = ConvertDate.ConvertShamsiToMiladi(model.OperationDateE),
                    ExpireDate = getInfo.ExpireDate,
                    RefferenceID = model.ReffernceInvID,
                    ProductLocationID = getInfo.ProductLocationID
                };
                await _context.inventoryUW.CreateAsync(I, ct);
                _context.Save();
                return Ok(I);

            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }

        [HttpGet("GetStockEachBranck")]
        public ApiResult<string> GetStockEachBranckApi(int InventoryID)
        {
            var getLocationAddress = _context.inventoryUW.Get(i => i.InventoryID == InventoryID, "ProductLocations_Tbl").
                Select(s => s.ProductLocations_Tbl.ProductLocationAddress).Single();

            return Ok(_inventory.GetPhysicalStockForBranch(InventoryID));

        }

        [HttpGet("GetWastageStockEachBranch")]
        public ApiResult<string> GetWastageStockEachBranchApi(int InventoryID)
        {
            var getLocationAddress = _context.inventoryUW.Get(i => i.InventoryID == InventoryID, "ProductLocations_Tbl").
                Select(s => s.ProductLocations_Tbl.ProductLocationAddress).Single();

            return Ok(_inventory.GetPhysicalWastageStockForBranch(InventoryID));
        }

        [HttpPost]
        [Route("WastageProductStockApi")]
        public async Task<ApiResult<string>> WastageProductStock([FromForm] WastageStockModel model, CancellationToken ct)
        {
            //ثبت ضایعات
            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");

            if (model.ProductCountWastage > _inventory.GetPhysicalStockForBranch(model.ReffernceInvIDWastage))
            {
                return BadRequest(model.ProductCountWastage);
                //{
                //    flag = false,
                //    StatusCode = ApiResultStatusCode.ListEmpty,
                //    Message = "تعداد ضایعات بیشتر از موجودی فیزیکی کالا می باشد."
                //};
            }

            try
            {
                var getParentInfo = _context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvIDWastage).Single();
                Inventories_Tbl I = new Inventories_Tbl
                {
                    ProductID = model.ProductIDWastage,
                    WareHouseID = model.WareHouseIDWastage,
                    FiscalYearID = model.FiscalYearIDWastage,
                    UserID = model.UserIDWastage,
                    CreateDateTime = DateTime.Now,
                    Description = model.DescriptionWastage,
                    OperationType = 3, //ثبت ضایعات
                    ProductCountMain = 0,
                    ProductCountWastage = model.ProductCountWastage,
                    OperationDate = ConvertDate.ConvertShamsiToMiladi(model.OperationDateWastage),
                    ExpireDate = getParentInfo.ExpireDate,
                    RefferenceID = model.ReffernceInvIDWastage,
                    ProductLocationID = getParentInfo.ProductLocationID
                };
                await _context.inventoryUW.CreateAsync(I, ct);
                _context.Save();
                return Ok(I);

            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }

        [HttpPost]
        [Route("BackWastageProductStockApi")]
        public async Task<ApiResult<string>> BackWastageProductStock([FromForm] BackWastageStockModel model, CancellationToken ct)
        {
            //برگشت از ضایعات
            if (!ModelState.IsValid) return BadRequest("پارامتر نامعتبر");

            if (model.ProductCountBackWastage > _inventory.GetPhysicalWastageStockForBranch(model.ReffernceInvIDBackWastage))
            {
                return BadRequest(model.ProductCountBackWastage);
                //{
                //    flag = false,
                //    StatusCode = ApiResultStatusCode.ListEmpty,
                //    Message = "تعداد کالا بیشتر از موجودی ضایعات کالا می باشد."
                //};
            }

            try
            {
                var getParentInfo = _context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvIDBackWastage).Single();
                Inventories_Tbl I = new Inventories_Tbl
                {
                    ProductID = model.ProductIDBackWastage,
                    WareHouseID = model.WareHouseIDBackWastage,
                    FiscalYearID = model.FiscalYearIDBackWastage,
                    UserID = model.UserIDBackWastage,
                    CreateDateTime = DateTime.Now,
                    Description = model.DescriptionBackWastage,
                    OperationType = 4, //برگشت از ضایعات
                    ProductCountMain = 0,
                    ProductCountWastage = model.ProductCountBackWastage,
                    OperationDate = ConvertDate.ConvertShamsiToMiladi(model.OperationDateBackWastage),
                    ExpireDate = getParentInfo.ExpireDate,
                    RefferenceID = model.ReffernceInvIDBackWastage,
                    ProductLocationID = getParentInfo.ProductLocationID
                };
                await _context.inventoryUW.CreateAsync(I, ct);
                _context.Save();
                return Ok(I);

            }
            catch (Exception)
            {
                return BadRequest("پارامتر نامعتبر");
            }
        }

        [HttpGet("GetWareHouseHandling")]
        public ApiResult<IEnumerable<ProductListExpireOrinted>> GetWareHouseHandling([FromBody] InventoryQueryMaker model)
        {
            var query = _inventory.ProductListExpireOriented(model);
            return Ok(query);
        }
    }
}