using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class RialiStockRepository : UnitOfWork, IRialiStockRepository
    {

        public RialiStockRepository(ApplicationDbContext context) : base(context)
        {

        }

        public List<RialiStockDto> GetRialiStock(int FiscalYearID, int WareHouseID)
        {
            //لیست همه قیمت ها
            var lstPriceList = this.productPriceUW.Get().AsEnumerable();
            //لیست همه تراکنش ها
            var StockList = this.inventoryUW.Get(i => i.FiscalYearID == FiscalYearID && i.WareHouseID == WareHouseID).AsEnumerable();
            //
            var lstProductRialiStock = (from p in this.productUW.Get().ToList()
                                        select new RialiStockDto
                                        {
                                            ProductID = p.ProductID,
                                            ProductName = p.ProductName,
                                            ProductCode = p.ProductCode,
                                            TotalPurchPrice = (lstPriceList.Where(purchase => purchase.ActionDate <= DateTime.Now &&
                                                                                           purchase.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.PurchasePrice).DefaultIfEmpty().Single())
                                          * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                                         s.OperationType == 6 ? s.ProductCountMain :
                                         s.OperationType == 3 ? -s.ProductCountWastage :
                                         s.OperationType == 4 ? s.ProductCountWastage :
                                         s.OperationType == 2 ? -s.ProductCountMain :
                                         s.OperationType == 5 ? -s.ProductCountMain :
                                         s.OperationType == 7 ? s.ProductCountMain :
                                         s.OperationType == 8 ? -s.ProductCountMain :
                                         s.OperationType == 9 ? s.ProductCountMain : 0)),



                                            TotalCoverPrice = (lstPriceList.Where(cover => cover.ActionDate <= DateTime.Now &&
                                                                                           cover.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.CoverPrice).DefaultIfEmpty().Single())
                                          * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                                         s.OperationType == 6 ? s.ProductCountMain :
                                         s.OperationType == 3 ? -s.ProductCountWastage :
                                         s.OperationType == 4 ? s.ProductCountWastage :
                                         s.OperationType == 2 ? -s.ProductCountMain :
                                         s.OperationType == 5 ? -s.ProductCountMain :
                                         s.OperationType == 7 ? s.ProductCountMain :
                                         s.OperationType == 8 ? -s.ProductCountMain :
                                         s.OperationType == 9 ? s.ProductCountMain : 0)),



                                            TotalSalePrice = (lstPriceList.Where(sales => sales.ActionDate <= DateTime.Now &&
                                                                                           sales.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.SalesPrice).DefaultIfEmpty().Single())
                                         * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                                         s.OperationType == 6 ? s.ProductCountMain :
                                         s.OperationType == 3 ? -s.ProductCountWastage :
                                         s.OperationType == 4 ? s.ProductCountWastage :
                                         s.OperationType == 2 ? -s.ProductCountMain :
                                         s.OperationType == 5 ? -s.ProductCountMain :
                                         s.OperationType == 7 ? s.ProductCountMain :
                                         s.OperationType == 8 ? -s.ProductCountMain :
                                         s.OperationType == 9 ? s.ProductCountMain : 0)),

                                            TotalProductCount = StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 1 ? s.ProductCountMain :
                                         s.OperationType == 6 ? s.ProductCountMain :
                                         s.OperationType == 3 ? -s.ProductCountWastage :
                                         s.OperationType == 4 ? s.ProductCountWastage :
                                         s.OperationType == 2 ? -s.ProductCountMain :
                                         s.OperationType == 5 ? -s.ProductCountMain :
                                          s.OperationType == 7 ? s.ProductCountMain :
                                         s.OperationType == 8 ? -s.ProductCountMain :
                                         s.OperationType == 9 ? s.ProductCountMain : 0)

                                        });

            return lstProductRialiStock.ToList();
        }
    }
}
