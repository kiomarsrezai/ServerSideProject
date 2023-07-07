using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop.Infrastructure;
using WareHousingApi.Common;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;
using WareHousingApi.Entities.Models;
using WareHousingApi.Entities.Models.Dto;
using WareHousingApi.WebFramework.StandardApiResult;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IInvoiceRepository _invoice;
        private readonly IInventoryRepository _inventory;

        public InvoiceApiController(IUnitOfWork context, IInvoiceRepository invoice, IInventoryRepository inventory)
        {
            _context = context;
            _invoice = invoice;
            _inventory = inventory;
        }

        [HttpGet("GetProductItemInfo")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse<ProductItemDto> GetProductItemInfo(string productcode, int warehouseid, int fiscalyearid)
        {
            try
            {
                var productInfo = _invoice.GetProductItemInfo(productcode, warehouseid, fiscalyearid);
                return new ApiResponse<ProductItemDto>
                {
                    flag = true,
                    Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                    StatusCode = ApiResultStatusCode.Success,
                    Data = productInfo
                };
            }
            catch (Exception)
            {
                return new ApiResponse<ProductItemDto>
                {
                    flag = false,
                    Message = "هیچ کالایی یافت نشد.",
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Data = null
                };
            }
        }

        [HttpPost]
        [Route("CreateNewInvoice")]
        public ApiResponse CreateInvoice([FromBody] CreateInvoiceViewModel model)
        {
            if (model == null || model.productid.Count() == 0 ||
                model.productcount.Count() == 0 ||
                (model.productid.Count() != model.productcount.Count()))
            {
                return new ApiResponse
                {
                    //590
                    flag = false,
                    StatusCode = ApiResultStatusCode.ListEmpty,
                    Message = ApiResultStatusCode.ListEmpty.DisplayNameAttribute()
                };
            }

            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    //Create Invoice Number
                    string CreateInvoiceNo = "1";
                    if (_context.invoicesUW.Get().Count() > 0)
                    {
                        CreateInvoiceNo = (_context.invoicesUW.Get().OrderByDescending(d => d.InvoiceID)
                            .Select(s => s.InvoiceID).First() + 1) + "";
                    }
                    //
                    //1 = Create Invoice
                    Invoices_Tbl I = new Invoices_Tbl
                    {
                        CustomerID = model.customerid,
                        WareHouseID = model.warehouseid,
                        CreateDateTime = DateTime.Now,
                        InvoiceType = 1, //foroosh
                        InvoiceStatus = model.invoicestatus, //Close Invoice 
                        UserID = model.userid,
                        FiscalYearID = model.fiscalyearid,
                        InvoiceNo = ConvertDate.ConvertMiladiToShamsi(DateTime.Now, "yyyy/MM/dd").Replace("/", "") + CreateInvoiceNo,
                        InvoiceTotalPrice = _invoice.CalculateInvoicePrice(model.productid, model.productcount, model.fiscalyearid)
                    };
                    _context.invoicesUW.Create(I);
                    _context.Save();

                    //2 = Insert InvoiceItem
                    for (int i = 0; i < model.productid.Count(); i++)
                    {
                        //Check Product Stock
                        if (model.productcount[i] > _inventory.GetOneProductStock(model.productid[i], model.warehouseid, model.fiscalyearid))
                        {
                            return new ApiResponse
                            {
                                flag = false,
                                StatusCode = ApiResultStatusCode.UserMistake,
                                Message = _context.productUW.GetById(model.productid[i]).ProductName
                            };
                        }


                        InvoiceItems_Tbl II = new InvoiceItems_Tbl
                        {
                            UserID = model.userid,
                            CreateDateTime = DateTime.Now,
                            InvoiceID = I.InvoiceID,
                            ProductID = model.productid[i],
                            ProductCount = model.productcount[i],
                            PurchasePrice = _invoice.GetPurchasePrice(model.productid[i]),
                            SalesPrice = _invoice.GetSalesPrice(model.productid[i]),
                            CoverPrice = _invoice.GetCoverPrice(model.productid[i])
                        };
                        _context.invoicesItemsUW.Create(II);

                        if (model.invoicestatus == 1)
                        {
                            //کسر از موجودی
                            GetProductFromBranch(model.productid[i], model.productcount[i],
                                                 model.fiscalyearid, model.warehouseid, model.userid, I.InvoiceID);
                        }
                    }
                    _context.Save();
                    transaction.Commit();

                    return new ApiResponse
                    {
                        flag = true,
                        StatusCode = ApiResultStatusCode.Success,
                        Message = ApiResultStatusCode.Success.DisplayNameAttribute()
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return new ApiResponse
                    {
                        //590
                        flag = false,
                        StatusCode = ApiResultStatusCode.ServerError,
                        Message = ApiResultStatusCode.ServerError.DisplayNameAttribute()
                    };
                }
            }
        }

        private void GetProductFromBranch(int ProductID, int ProductCount, int FiscalYearID, int WareHouseID, string UserID, int InvoiceID)
        {
            // 1 = دریافت همه سری انقضاهای کالا
            var expireDateList = _context.inventoryUW.
                       Get(p => p.ProductID == ProductID &&
                           p.WareHouseID == WareHouseID &&
                           p.FiscalYearID == FiscalYearID &&
                           (p.OperationType == 1 || p.OperationType == 9)).OrderBy(o => o.ExpireDate).ToList();
            // 2 = حذف سری انقضاهایی که موجودی ندارند
            List<int> ZeroStocks = new List<int>();
            for (int i = 0; i < expireDateList.Count(); i++)
            {
                if (_inventory.GetPhysicalStockForBranch(expireDateList[i].InventoryID) == 0)
                {
                    ZeroStocks.Add(expireDateList[i].InventoryID);
                }
            }
            // 3 = مشخص کردن همه سری انقضاهای دارای موجودی بر اساس تاریخ انقضای نزدیکتر
            var expireDateListWithStock = expireDateList.Where(e => !ZeroStocks.Contains(e.InventoryID)).OrderBy(o => o.ExpireDate).ToList();
            // 4 = برداشت از سری انقضاهای تاریخ نزدیکتر تا اینکه سفارش کامل شود.
            int SavedStock = ProductCount;
            for (int j = 0; j < expireDateListWithStock.Count(); j++)
            {
                //بدست آوردن موجودی هر سری انقضا
                int getBranchStock = _inventory.GetPhysicalStockForBranch(expireDateListWithStock[j].InventoryID);
                if (SavedStock <= getBranchStock)
                {
                    Inventories_Tbl Inv = new Inventories_Tbl
                    {
                        CreateDateTime = DateTime.Now,
                        Description = "فروش",
                        OperationType = 5,
                        OperationDate = DateTime.Now,
                        FiscalYearID = FiscalYearID,
                        WareHouseID = WareHouseID,
                        InvoiceID = InvoiceID,
                        UserID = UserID,
                        ProductCountWastage = 0,
                        ProductCountMain = SavedStock,
                        ProductID = ProductID,
                        ExpireDate = expireDateListWithStock[j].ExpireDate,
                        RefferenceID = expireDateListWithStock[j].InventoryID,
                        ProductLocationID = _context.inventoryUW.Get(i => i.InventoryID == expireDateListWithStock[j].InventoryID, "ProductLocations_Tbl").
                Select(s => s.ProductLocations_Tbl.ProductLocationID).Single()
                    };
                    _context.inventoryUW.Create(Inv);
                    break;
                }
                else if (SavedStock > getBranchStock)
                {
                    SavedStock -= getBranchStock;
                    Inventories_Tbl Inv = new Inventories_Tbl
                    {
                        CreateDateTime = DateTime.Now,
                        Description = "فروش",
                        OperationType = 5,
                        OperationDate = DateTime.Now,
                        FiscalYearID = FiscalYearID,
                        WareHouseID = WareHouseID,
                        InvoiceID = InvoiceID,
                        UserID = UserID,
                        ProductCountWastage = 0,
                        ProductCountMain = getBranchStock,
                        ProductID = ProductID,
                        ExpireDate = expireDateListWithStock[j].ExpireDate,
                        RefferenceID = expireDateListWithStock[j].InventoryID,
                        ProductLocationID = _context.inventoryUW.Get(i => i.InventoryID == expireDateListWithStock[j].InventoryID, "ProductLocations_Tbl").
               Select(s => s.ProductLocations_Tbl.ProductLocationID).Single()
                    };
                    _context.inventoryUW.Create(Inv);
                }
                _context.Save();
            }
        }

        [HttpGet("InvoiceListApi")]
        public ApiResponse<List<InvoiceListDto>> InvoiceListApi(RecieveParametersInvoiceList model)
        {
            if (model.FromDate == "" || model.FromDate == null)
            {
                model.FromDate = "1300/01/01";
            }
            if (model.ToDate == "" || model.ToDate == null)
            {
                model.ToDate = "1600/01/01";
            }
            List<InvoiceListDto> query = _invoice.InvoiceListFullInfo(model);
            return new ApiResponse<List<InvoiceListDto>>
            {
                flag = true,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                StatusCode = ApiResultStatusCode.Success,
                Data = query
            };
        }

        [HttpGet("InvoiceItemList")]
        public ApiResponse<List<InvoiceItemListViewModel>> InvoiceItemList(int InvoiceID)
        {
            if (InvoiceID == 0)
            {
                return new ApiResponse<List<InvoiceItemListViewModel>>
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute(DisplayProperty.Name),
                };
            }
            var query = _invoice.GetInvoiceItemList(InvoiceID);
            return new ApiResponse<List<InvoiceItemListViewModel>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name),
                Data = query
            };
        }

        [HttpPost("ReturnInvoiceApi")]
        public ApiResponse ReturnInvoiceApi([FromBody] ReturnInvoiceDto model)
        {
            if (model.InvoiceID == 0)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute()
                };
            }

            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    //Set InvoiceType = 2 -- Invoice
                    var getReturnInvoice = _context.invoicesUW.GetById(model.InvoiceID);
                    getReturnInvoice.InvoiceType = 2;
                    getReturnInvoice.ReturnInvoiceDateTime = DateTime.Now;
                    _context.invoicesUW.Update(getReturnInvoice);
                    _context.Save();

                    //2 = Inventory Operation
                    var getInventoryRecord = _context.inventoryUW.Get(i => i.InvoiceID == model.InvoiceID).ToList();
                    for (int i = 0; i < getInventoryRecord.Count(); i++)
                    {
                        Inventories_Tbl Inv = new Inventories_Tbl
                        {
                            CreateDateTime = DateTime.Now,
                            Description = "مرجوع",
                            OperationType = 6,
                            OperationDate = DateTime.Now,
                            FiscalYearID = model.FiscalYearID,
                            UserID = model.UserID,
                            InvoiceID = model.InvoiceID,
                            WareHouseID = getInventoryRecord[i].WareHouseID,
                            ProductLocationID = getInventoryRecord[i].ProductLocationID,
                            ExpireDate = getInventoryRecord[i].ExpireDate,
                            ProductCountMain = getInventoryRecord[i].ProductCountMain,
                            ProductCountWastage = 0,
                            ProductID = getInventoryRecord[i].ProductID,
                            RefferenceID = getInventoryRecord[i].RefferenceID,
                        };
                        _context.inventoryUW.Create(Inv);
                    }
                    _context.Save();
                    transaction.Commit();

                    return new ApiResponse
                    {
                        flag = true,
                        StatusCode = ApiResultStatusCode.Success,
                        Message = ApiResultStatusCode.Success.DisplayNameAttribute()
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return new ApiResponse
                    {
                        flag = false,
                        StatusCode = ApiResultStatusCode.ServerError,
                        Message = ApiResultStatusCode.ServerError.DisplayNameAttribute()
                    };
                }
            }

            return new ApiResponse
            {
                flag = false,
                StatusCode = ApiResultStatusCode.ServerError,
                Message = ApiResultStatusCode.ServerError.DisplayNameAttribute()
            };
        }

        [HttpPost("SetInvoiceToCloseApi")]
        public ApiResponse SetInvoiceToCloseApi([FromBody] SetInvoiceToCloseDto model)
        {
            if (model.InvoiceID == 0)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute()
                };
            }

            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    //Set InvoiceStatus = 1
                    var getInvoice = _context.invoicesUW.GetById(model.InvoiceID);
                    getInvoice.InvoiceStatus = 1;
                    _context.invoicesUW.Update(getInvoice);
                    _context.Save();

                    //2 = Inventory Operation
                    var getProductInfo =
                        _context.invoicesItemsUW.Get(i => i.InvoiceID == model.InvoiceID).ToList();
                    for (int i = 0; i < getProductInfo.Count(); i++)
                    {
                        GetProductFromBranch(getProductInfo[i].ProductID,
                                             getProductInfo[i].ProductCount,
                                             model.FiscalYearID,
                                             getInvoice.WareHouseID,
                                             model.UserID,
                                             model.InvoiceID);
                    }

                    _context.Save();
                    transaction.Commit();

                    return new ApiResponse
                    {
                        flag = true,
                        StatusCode = ApiResultStatusCode.Success,
                        Message = ApiResultStatusCode.Success.DisplayNameAttribute()
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return new ApiResponse
                    {
                        flag = false,
                        StatusCode = ApiResultStatusCode.ServerError,
                        Message = ApiResultStatusCode.ServerError.DisplayNameAttribute()
                    };
                }
            }

            return new ApiResponse
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(DisplayProperty.Name)
            };
        }

        [HttpPost("DeleteTemporaryInvoiceApi")]
        public ApiResponse DeleteTemporaryInvoiceApi([FromBody] int InvoiceID)
        {
            if (InvoiceID == 0)
            {
                return new ApiResponse
                {
                    flag = false,
                    StatusCode = ApiResultStatusCode.BadRequest,
                    Message = ApiResultStatusCode.BadRequest.DisplayNameAttribute()
                };
            }

            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    //Remove InvoiceItem Rows
                    _context.invoicesItemsUW.DeleteByRange(_context.invoicesItemsUW.Get(ii => ii.InvoiceID == InvoiceID));
                    _context.Save();
                    //Remove Invoice Row
                    _context.invoicesUW.DeleteById(InvoiceID);

                    _context.Save();
                    transaction.Commit();

                    return new ApiResponse
                    {
                        flag = true,
                        StatusCode = ApiResultStatusCode.Success,
                        Message = ApiResultStatusCode.Success.DisplayNameAttribute()
                    };
                }
                catch
                {
                    transaction.RollBack();
                    return new ApiResponse
                    {
                        flag = false,
                        StatusCode = ApiResultStatusCode.ServerError,
                        Message = ApiResultStatusCode.ServerError.DisplayNameAttribute()
                    };
                }
            }

            return new ApiResponse
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute()
            };
        }

        //For Print Invoice
        [HttpGet("GetInvoiceDetails/{InvoiceID}")]
        public ApiResponse<InvoiceDetailsPrintDto> GetInvoiceDetails(int InvoiceID)
        {
            return new ApiResponse<InvoiceDetailsPrintDto>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = _invoice.GetInvoiceDetailsFunc(InvoiceID)
            };
        }

        [HttpGet("AllProductInvoiced")]
        public ApiResponse<List<AllProductInvoicedDto>> AllProductInvoiced(IndeedParameterForAllProduct model)
        {
            if (model.fromdate.IsNullOrEmpty())
            {
                model.fromdate = "1300/01/01";
            }
            if (model.todate.IsNullOrEmpty())
            {
                model.todate = "1600/01/01";
            }

            return new ApiResponse<List<AllProductInvoicedDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = _invoice.AllProductInvoicedRepo(model)
            };
        }

        [HttpGet("GroupSeparationInvoice")]
        public ApiResponse<List<GroupInvoiceDto>> GroupSeparationInvoice(IndeedParameterGroupInvoiceDto model)
        {
            if (model.fromdate.IsNullOrEmpty())
            {
                model.fromdate = "1300/01/01";
            }
            if (model.todate.IsNullOrEmpty())
            {
                model.todate = "1600/01/01";
            }

            return new ApiResponse<List<GroupInvoiceDto>>
            {
                flag = true,
                StatusCode = ApiResultStatusCode.Success,
                Message = ApiResultStatusCode.Success.DisplayNameAttribute(),
                Data = _invoice.GroupInvoiceRepo(model)
            };
        }
    }
}