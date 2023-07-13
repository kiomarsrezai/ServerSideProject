using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Common;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Models;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class InvoiceRepository : UnitOfWork, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {

        }


        public ProductItemDto GetProductItemInfo(string productcode, int warehouseid, int fiscalyearid)
        {
            var query = this.productUW.Get(p => p.ProductCode == productcode)
                .Select(p => new ProductItemDto
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    CoverPrice = GetCoverPrice(p.ProductID),
                    PurchasePrice = GetPurchasePrice(p.ProductID),
                    SalesPrice = GetSalesPrice(p.ProductID),
                    ProductStock = GetProductStock(p.ProductID, warehouseid, fiscalyearid)
                }).Single();
            return query;
        }

        //موجودی
        private int GetProductStock(int productid, int warehouseid, int fiscalyearid)
        {
            int productStock =
                this.inventoryUW.Get(i => i.ProductID == productid && i.FiscalYearID == fiscalyearid && i.WareHouseID == warehouseid)
                .Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                s.OperationType == 6 ? s.ProductCountMain :
                s.OperationType == 3 ? -s.ProductCountWastage :
                s.OperationType == 4 ? s.ProductCountWastage :
                s.OperationType == 2 ? -s.ProductCountMain :
                s.OperationType == 5 ? -s.ProductCountMain :
                s.OperationType == 7 ? s.ProductCountMain :
                s.OperationType == 8 ? -s.ProductCountMain :
                s.OperationType == 9 ? s.ProductCountMain : 0);
            return productStock;
        }
        //قیمت خرید
        public int GetPurchasePrice(int productid)
        {
            int productpurchase = this.productPriceUW.Get(p => p.ActionDate <= DateTime.Now &&
            p.ProductID == productid).OrderByDescending(o => o.ActionDate).Take(1).Select(s => s.PurchasePrice).DefaultIfEmpty().Single();

            return productpurchase;
        }
        //قیمت فروش
        public int GetSalesPrice(int productid)
        {
            int productsales = this.productPriceUW.Get(p => p.ActionDate <= DateTime.Now &&
            p.ProductID == productid).OrderByDescending(o => o.ActionDate).Take(1).Select(s => s.SalesPrice).DefaultIfEmpty().Single();

            return productsales;
        }
        //قیمت مصرف کننده
        public int GetCoverPrice(int productid)
        {
            int productcover = this.productPriceUW.Get(p => p.ActionDate <= DateTime.Now &&
            p.ProductID == productid).OrderByDescending(o => o.ActionDate).Take(1).Select(s => s.CoverPrice).DefaultIfEmpty().Single();

            return productcover;
        }

        //محاسبه مبلغ کل فاکتور
        public int CalculateInvoicePrice(int[] productid, int[] productcount, int fiscalyearid)
        {
            int TotalPrice = 0;
            for (int i = 0; i < productid.Count(); i++)
            {
                TotalPrice += GetSalesPrice(productid[i]) * productcount[i];
            }

            return TotalPrice;
        }

        public List<InvoiceListDto> InvoiceListFullInfo(RecieveParametersInvoiceList model)
        {
            var query = this.invoicesUW
                .Get(i => i.WareHouseID == model.WareHouseID &&
                        i.FiscalYearID == model.FiscalYearID &&
                        //i.UserID == model.UserID)
                        (i.CreateDateTime.Date >= ConvertDate.ConvertShamsiToMiladi(model.FromDate) &&
                         i.CreateDateTime.Date <= ConvertDate.ConvertShamsiToMiladi(model.ToDate)), "Customers")
                .Select(s => new InvoiceListDto
                {
                    CustomerAddress = s.Customers.CustomerAddress,
                    CustomerID = s.CustomerID,
                    CustomerName = s.Customers.CustomerFullName,
                    CustomerTel = s.Customers.CustomerTel,
                    FiscalYearID = s.FiscalYearID,
                    InvoiceDate = s.CreateDateTime,
                    InvoiceID = s.InvoiceID,
                    InvoiceNo = s.InvoiceNo,
                    InvoiceType = s.InvoiceType,
                    TotalInvoicePrice = s.InvoiceTotalPrice,
                    InvoiceStatus = s.InvoiceStatus,
                    ReturnInvoiceDateTime = (DateTime)(s.ReturnInvoiceDateTime == null ? DateTime.MinValue : s.ReturnInvoiceDateTime)
                });

            return query.OrderByDescending(p => p.InvoiceID).ToList();
        }

        public List<InvoiceItemListViewModel> GetInvoiceItemList(int InvoiceID)
        {
            var query = this.invoicesItemsUW.Get(ii => ii.InvoiceID == InvoiceID, "Products")
                .Select(s => new InvoiceItemListViewModel
                {
                    ProductID = s.ProductID,
                    ProductCount = s.ProductCount,
                    CoverPrice = s.CoverPrice,
                    PurchasePrice = s.PurchasePrice,
                    SalesPrice = s.SalesPrice,
                    ProductCode = s.Products.ProductCode,
                    ProductName = s.Products.ProductName
                });

            return query.ToList();
        }

        //For Invoice Print
        public InvoiceDetailsPrintDto GetInvoiceDetailsFunc(int InvoiceID)
        {
            var query = this.invoicesUW.Get(i => i.InvoiceID == InvoiceID, "Customers")
                .Select(s => new InvoiceDetailsPrintDto
                {
                    CustomerAddress = s.Customers.CustomerAddress,
                    CustomerName = s.Customers.CustomerFullName,
                    CustomerTel = s.Customers.CustomerTel,
                    InvoiceNo = s.InvoiceNo,
                    InvoiceID = s.InvoiceID,
                    InvoiceDate = s.CreateDateTime,
                    InvoiceTotalPrice = s.InvoiceTotalPrice,
                    ItemList = this.invoicesItemsUW.Get(ii => ii.InvoiceID == InvoiceID, "Products")
                    .Select(item => new InvoiceItemForPrint
                    {
                        ProductCode = item.Products.ProductCode,
                        ProductName = item.Products.ProductName,
                        ProductID = item.ProductID,
                        ProductPrice = item.SalesPrice,
                        ProductCount = item.ProductCount
                    }).ToList()
                });

            return query.Single();
        }

        public List<AllProductInvoicedDto> AllProductInvoicedRepo(IndeedParameterForAllProduct model)
        {
            var query = this.inventoryUW.Get(inv => inv.WareHouseID == model.WareHouseID
                                                 && inv.FiscalYearID == model.FiscalYearID
                                                 && (inv.OperationDate.Date >= ConvertDate.ConvertShamsiToMiladi(model.fromdate)
                                                 && inv.OperationDate.Date <= ConvertDate.ConvertShamsiToMiladi(model.todate))
                                                 && inv.OperationType == 5, "Products")
                .GroupBy(x => new { x.ProductID, x.Products.ProductName, x.Products.ProductCode, x.ExpireDate })
                .Select(s => new AllProductInvoicedDto
                {
                    ExpireDate = s.Key.ExpireDate,
                    ProductID = s.Key.ProductID,
                    ProductCode = s.Key.ProductCode,
                    ProductName = s.Key.ProductName,
                    ProductCount = s.Sum(p => p.ProductCountMain)
                });
            return query.ToList();
        }

        public List<GroupInvoiceDto> GroupInvoiceRepo(IndeedParameterGroupInvoiceDto model)
        {
            var query = this.invoicesItemsUW.Get(ii => ii.Invoices.WareHouseID == model.WareHouseID
                                                    && (ii.CreateDateTime.Date >= ConvertDate.ConvertShamsiToMiladi(model.fromdate)
                                                    && ii.CreateDateTime.Date <= ConvertDate.ConvertShamsiToMiladi(model.todate)),
                                                    "Products,Invoices").Where(i=>i.Invoices.FiscalYearID == model.FiscalYearID)
                .Select(s => new GroupInvoiceDto
                {
                    InvoiceID = s.InvoiceID,
                    InvoiceNo = s.Invoices.InvoiceNo,
                    ProductCode = s.Products.ProductCode,
                    ProductName = s.Products.ProductName,
                    ProductCount = s.ProductCount,
                    ProductID = s.ProductID
                });
            return query.ToList();
        }
    }
}
