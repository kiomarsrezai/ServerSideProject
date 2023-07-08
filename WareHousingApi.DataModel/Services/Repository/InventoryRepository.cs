using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class InventoryRepository : UnitOfWork, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        //دریافت موجودی یک کالای خاص در یک انبار
        public int GetOneProductStock(int ProductID, int WareHouseID, int FiscalYearID)
        {
            return this.inventoryUW.Get(i => i.ProductID == ProductID &&
                                        i.FiscalYearID == FiscalYearID &&
                                        i.WareHouseID == WareHouseID)
                    .Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                              s.OperationType == 6 ? s.ProductCountMain :
                              s.OperationType == 3 ? -s.ProductCountWastage :
                              s.OperationType == 4 ? s.ProductCountWastage :
                              s.OperationType == 2 ? -s.ProductCountMain :
                              s.OperationType == 5 ? -s.ProductCountMain :
                              s.OperationType == 7 ? s.ProductCountMain :
                              s.OperationType == 8 ? -s.ProductCountMain :
                              s.OperationType == 9 ? s.ProductCountMain : 0);
        }

        public List<InventoryStockModel> GetProductStock(InventoryQueryMaker model)
        {
            var lstProductStock =
                (from p in this.productUW.Get().ToList()
                 select new InventoryStockModel
                 {
                     ProductCode = p.ProductCode,
                     ProductID = p.ProductID,
                     ProductName = p.ProductName,


                     TotalProductCount = this.inventoryUW.Get(i => i.ProductID == p.ProductID &&
                                                                             i.FiscalYearID == model.FiscalYearID &&
                                                                             i.WareHouseID == model.WareHouseID)
                     .Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                               s.OperationType == 6 ? s.ProductCountMain :
                               s.OperationType == 3 ? -s.ProductCountWastage :
                               s.OperationType == 4 ? s.ProductCountWastage :
                               s.OperationType == 2 ? -s.ProductCountMain :
                               s.OperationType == 5 ? -s.ProductCountMain :
                               s.OperationType == 7 ? s.ProductCountMain :
                               s.OperationType == 8 ? -s.ProductCountMain :
                               s.OperationType == 9 ? s.ProductCountMain : 0),



                     TotalProductWaste = this.inventoryUW.Get(i => i.ProductID == p.ProductID &&
                                                                             i.FiscalYearID == model.FiscalYearID &&
                                                                             i.WareHouseID == model.WareHouseID &&
                                                                             i.ProductCountWastage > 0).Sum
                               (s => s.OperationType == 3 ? s.ProductCountWastage :
                               s.OperationType == 4 ? -s.ProductCountWastage : 0)

                 });

            return lstProductStock.ToList();
        }

        public int GetPhysicalStockForBranch(int InventoryID)
        {
            //دریافت موجودی هر سری ساخت
            var getStock = this.inventoryUW.Get(i => i.InventoryID == InventoryID || i.RefferenceID == InventoryID)
                .Select(s => s.InventoryID).ToList();

            int getStock2 = this.inventoryUW
                .Get(i2 => getStock.Contains(i2.RefferenceID) || i2.InventoryID == InventoryID).ToList()
                    .Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                               s.OperationType == 6 ? s.ProductCountMain :
                               s.OperationType == 3 ? -s.ProductCountWastage :
                               s.OperationType == 4 ? s.ProductCountWastage :
                               s.OperationType == 2 ? -s.ProductCountMain :
                               s.OperationType == 5 ? -s.ProductCountMain :
                               s.OperationType == 7 ? s.ProductCountMain :
                               s.OperationType == 8 ? -s.ProductCountMain :
                               s.OperationType == 9 ? s.ProductCountMain : 0);

            return getStock2;
        }

        public int GetPhysicalWastageStockForBranch(int InventoryID)
        {
            //دریافت موجودی هر سری ساخت
            int getStock = this.inventoryUW.Get(i => i.InventoryID == InventoryID || i.RefferenceID == InventoryID)
                    .Sum(s => s.OperationType == 3 ? s.ProductCountWastage :
                               s.OperationType == 4 ? -s.ProductCountWastage : 0);

            return getStock;
        }

        public List<ProductListExpireOrinted> ProductListExpireOriented(InventoryQueryMaker model)
        {
            //آخرین موجودی هر کالا بر اساس تاریخ انقضا
            IList<ProductListExpireOrinted2> expireDataList = this.inventoryUW.
                Get(p => p.WareHouseID == model.WareHouseID && p.FiscalYearID == model.FiscalYearID
                && (p.OperationType == 1 || p.OperationType == 9), "Products")
                .OrderBy(o => o.ExpireDate)
                .GroupBy(g => new { g.ProductID, g.Products.ProductName, g.Products.ProductCode, g.ExpireDate, g.InventoryID })
                .Select(c => new ProductListExpireOrinted2
                {
                    ProductName = c.Key.ProductName,
                    ProductCode = c.Key.ProductCode,
                    ProductID = c.Key.ProductID,
                    ExpireDate = c.Key.ExpireDate,
                    TotalProductCount = GetPhysicalStockForBranch(c.Key.InventoryID),
                    InventoryID = c.Key.InventoryID
                }).ToList();

            //حذف تاریخ انقضاهای موجودی صفر
            List<int> zeroStock = new List<int>();
            for (int i = 0; i < expireDataList.Count; i++)
            {
                if (GetPhysicalStockForBranch(expireDataList[i].InventoryID) == 0)
                {
                    zeroStock.Add(expireDataList[i].InventoryID);
                }
            }
            //حذف موجودی صفرها از لیست اصلی

            return expireDataList.Where(e => !zeroStock.Contains(e.InventoryID))
                .GroupBy(s => new { s.ProductID, s.ProductName, s.ProductCode, s.ExpireDate })
                .Select(f => new ProductListExpireOrinted
                {
                    ExpireDate = f.Key.ExpireDate,
                    ProductCode = f.Key.ProductCode,
                    ProductName = f.Key.ProductName,
                    ProductID = f.Key.ProductID,
                    TotalProductCount = f.Sum(e => e.TotalProductCount)
                }).ToList();
        }

        public void TransferToNewFiscalYearRepo(CloseFiscalModel model)
        {
            //آخرین موجودی هر کالا بر اساس تاریخ انقضا
            IList<TransferToNewFiscalYearDto2> expireDataList = this.inventoryUW.
                Get(p => p.WareHouseID == model.warehouseid && p.FiscalYearID == model.fiscalyearid
                && (p.OperationType == 1 || p.OperationType == 9), "Products")
                .OrderBy(o => o.ExpireDate)
                .GroupBy(g => new { g.ProductID, g.ExpireDate, g.InventoryID })
                .Select(c => new TransferToNewFiscalYearDto2
                {
                    ProductID = c.Key.ProductID,
                    ExpireDate = c.Key.ExpireDate,
                    TotalProductCount = GetPhysicalStockForBranch(c.Key.InventoryID),
                    InventoryID = c.Key.InventoryID
                }).ToList();

            //حذف تاریخ انقضاهای موجودی صفر
            List<int> zeroStock = new List<int>();
            for (int i = 0; i < expireDataList.Count; i++)
            {
                if (GetPhysicalStockForBranch(expireDataList[i].InventoryID) == 0)
                {
                    zeroStock.Add(expireDataList[i].InventoryID);
                }
            }
            //حذف موجودی صفرها از لیست اصلی

            var pureExList = expireDataList.Where(e => !zeroStock.Contains(e.InventoryID))
                .GroupBy(s => new { s.ProductID, s.ExpireDate })
                .Select(f => new TransferToNewFiscalYearDto
                {
                    ExpireDate = f.Key.ExpireDate,
                    ProductID = f.Key.ProductID,
                    TotalProductCount = f.Sum(e => e.TotalProductCount)
                }).ToList();

            //دریافت تاریخ پایان سال مالی باز
            DateTime LastEndDate = (this.fiscalYearUW.Get(f1 => f1.FiscalFlag == true).Select(s => s.EndDate.Date).Single());
            //دریافت آیدی سال مالی جدید و بسته
            var newFiscalID = this.fiscalYearUW.Get(f => f.FiscalFlag == false && f.StartDate.Date > LastEndDate).Select(f => f.FiscalYearID).Single();

            //بستن سال مالی قبلی و باز کردن سال مالی جدید
            var getfiscal = this.fiscalYearUW.Get();
            var getOldFiscal = getfiscal.Where(g1 => g1.FiscalYearID == model.fiscalyearid).Single();
            getOldFiscal.FiscalFlag = false;
            this.fiscalYearUW.Update(getOldFiscal);
            //
            var getNewFiscal = getfiscal.Where(g2 => g2.FiscalYearID == newFiscalID).Single();
            getNewFiscal.FiscalFlag = true;
            this.fiscalYearUW.Update(getNewFiscal);

            //ثبت اسناد در دیتابیس
            for (int i = 0; i < pureExList.Count(); i++)
            {
                Inventory Inv = new Inventory
                {
                    OperationType = 9,
                    CreateDateTime = DateTime.Now,
                    Description = "اسناد انتقالی سال مالی",
                    InvoiceID = 0,
                    OperationDate = DateTime.Now,
                    ProductID = pureExList[i].ProductID,
                    ProductCountMain = pureExList[i].TotalProductCount,
                    ExpireDate = pureExList[i].ExpireDate,
                    RefferenceID = 0,
                    UserID = model.userid,
                    WareHouseID = model.warehouseid,
                    ProductCountWastage = 0,
                    ProductLocationID = this.productLocationUW.Get(p => p.ProductLocationAddress.Contains("عمومی") && p.WareHouseID == model.warehouseid)
                    .Select(s => s.ProductLocationID).Single(),
                    FiscalYearID = newFiscalID
                };

                this.inventoryUW.Create(Inv);
            }

            this.Save();
        }
    }
}