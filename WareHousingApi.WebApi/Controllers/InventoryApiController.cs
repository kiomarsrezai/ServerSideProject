using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.WebFramework.StandardApiResult;

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
        public ApiResponse<IEnumerable<Inventory>> Get()
        {
            var inventoryList = _context.inventoryUW.Get();
            return new ApiResponse<IEnumerable<Inventory>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = inventoryList
            };
        }

        [HttpGet("GetProductStock")]
        public ApiResponse<IEnumerable<InventoryStockModel>> GetProductStock([FromBody] InventoryQueryMaker model)
        {
            var inventoryStockList = _inventory.GetProductStock(model);
            return new ApiResponse<IEnumerable<InventoryStockModel>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = inventoryStockList
            };
        }

        [HttpPost]
        [Route("AddProductStockApi")]
        public async Task<ApiResponse> AddProductStock([FromForm] AddStockModel model, CancellationToken ct)
        {
            //حواله ورود به انبار
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            try
            {
                byte OperationTypeVal =
                    (byte)(model.BalanceStockAdd == "on" ? 7 : (model.BalanceStockAdd == "" || model.BalanceStockAdd == null) ? 1 : 0);
                Inventory I = new Inventory
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
                _context.inventoryUW.CreateAsync(I, ct);
                await _context.SaveAsync();
                return new ApiResponse<Inventory>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = I
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

        [HttpGet("ProductExpireListDropDown")]
        public ApiResponse ProductExpireList(int ProductID, int FiscalYearID, int WareHouseID)
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
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = expireDateList.Where(e => !ZeroStocks.Contains(e.DrId)).ToList()
            };
        }

        [HttpGet("ProductExpireListBWDropDown")]
        public ApiResponse ProductExpireListBW(int ProductID, int FiscalYearID, int WareHouseID)
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
            return new ApiResponse<IEnumerable<DropDownDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = expireDateList.Where(e => !ZeroStocks.Contains(e.DrId)).ToList()
            };
        }

        [HttpPost]
        [Route("ExitProductStockApi")]
        public ApiResponse ExitProductStock([FromForm] ExitStockModel model, CancellationToken ct)
        {
            //حواله خروج از انبار
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (model.ProductCountMainE > _inventory.GetPhysicalStockForBranch(model.ReffernceInvID))
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ListEmpty,
                    Message = "تعداد کالای وارد شده بیشتر از موجودی فیزیکی کالا جهت خروج می باشد."
                };
            }

            try
            {
                byte OperationTypeVal =
             (byte)(model.BalanceStockRemove == "on" ? 8 : (model.BalanceStockRemove == "" || model.BalanceStockRemove == null) ? 2 : 0);

                var getInfo =_context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvID).Single();
                Inventory I = new Inventory
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
                _context.inventoryUW.CreateAsync(I, ct);
                _context.Save();
                return new ApiResponse<Inventory>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = I
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

        [HttpGet("GetStockEachBranck")]
        public ApiResponse GetStockEachBranckApi(int InventoryID)
        {
            var getLocationAddress = _context.inventoryUW.Get(i => i.InventoryID == InventoryID, "ProductLocations_Tbl").
                Select(s => s.ProductLocations_Tbl.ProductLocationAddress).Single();

            return new ApiResponse<int>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                //محل استقرار کالا
                Message = getLocationAddress,
                //تعداد موجودی در این سری ساخت
                Data = _inventory.GetPhysicalStockForBranch(InventoryID)
            };
        }

        [HttpGet("GetWastageStockEachBranch")]
        public ApiResponse GetWastageStockEachBranchApi(int InventoryID)
        {
            var getLocationAddress = _context.inventoryUW.Get(i => i.InventoryID == InventoryID, "ProductLocations_Tbl").
                Select(s => s.ProductLocations_Tbl.ProductLocationAddress).Single();

            return new ApiResponse<int>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                //محل استقرار کالا
                Message = getLocationAddress,
                //تعداد موجودی در این سری ساخت
                Data = _inventory.GetPhysicalWastageStockForBranch(InventoryID)
            };
        }

        [HttpPost]
        [Route("WastageProductStockApi")]
        public async Task<ApiResponse> WastageProductStock([FromForm] WastageStockModel model, CancellationToken ct)
        {
            //ثبت ضایعات
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (model.ProductCountWastage > _inventory.GetPhysicalStockForBranch(model.ReffernceInvIDWastage))
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ListEmpty,
                    Message = "تعداد ضایعات بیشتر از موجودی فیزیکی کالا می باشد."
                };
            }

            try
            {
                var getParentInfo = _context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvIDWastage).Single();
                Inventory I = new Inventory
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
                _context.inventoryUW.CreateAsync(I, ct);
                await _context.SaveAsync();
                return new ApiResponse<Inventory>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = I
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

        [HttpPost]
        [Route("BackWastageProductStockApi")]
        public async Task<ApiResponse> BackWastageProductStock([FromForm] BackWastageStockModel model, CancellationToken ct)
        {
            //برگشت از ضایعات
            if (!ModelState.IsValid) return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.BadRequest,
                Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name)
            };

            if (model.ProductCountBackWastage > _inventory.GetPhysicalWastageStockForBranch(model.ReffernceInvIDBackWastage))
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.ListEmpty,
                    Message = "تعداد کالا بیشتر از موجودی ضایعات کالا می باشد."
                };
            }

            try
            {
                var getParentInfo = _context.inventoryUW.Get(i => i.InventoryID == model.ReffernceInvIDBackWastage).Single();
                Inventory I = new Inventory
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
                _context.inventoryUW.CreateAsync(I, ct);
                await _context.SaveAsync();
                return new ApiResponse<Inventory>
                {
                    flag = true,
                    StatusCode = ApiResultStatusCode.Success,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                    Data = I
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

        [HttpGet("GetWareHouseHandling")]
        public ApiResponse<IEnumerable<ProductListExpireOrinted>> GetWareHouseHandling([FromBody] InventoryQueryMaker model)
        {
            var query = _inventory.ProductListExpireOriented(model);
            return new ApiResponse<IEnumerable<ProductListExpireOrinted>>
            {
                flag = false,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = query
            };
        }
    }
}