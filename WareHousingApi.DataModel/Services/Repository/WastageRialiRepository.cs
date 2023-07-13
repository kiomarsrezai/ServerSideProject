using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class WastageRialiRepository : UnitOfWork, IWastageRialiRepository
    {

        public WastageRialiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public List<WastageRialiStock> GetWastageRialiStock(int FiscalYearID, int WareHouseID)
        {
            //لیست همه قیمت ها
            var lstPriceList = this.productPriceUW.Get().AsEnumerable();
            //لیست همه تراکنش ها
            var StockList = this.inventoryUW.Get(i => i.FiscalYearID == FiscalYearID && i.WareHouseID == WareHouseID && (i.OperationType == 3 || i.OperationType == 4)).AsEnumerable();
            //
            var lstProductRialiStock = (from p in this.productUW.Get().ToList()
                                        select new WastageRialiStock
                                        {
                                            ProductID = p.ProductID,
                                            ProductName = p.ProductName,
                                            ProductCode = p.ProductCode,
                                            TotalWastagePurchPrice = (lstPriceList.Where(purchase => purchase.ActionDate <= DateTime.Now &&
                                                                                           purchase.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.PurchasePrice).DefaultIfEmpty().Single())
                                          * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 3 ? s.ProductCountWastage :
                                         s.OperationType == 4 ? -s.ProductCountWastage : 0)),



                                            TotalWastageCoverPrice = (lstPriceList.Where(cover => cover.ActionDate <= DateTime.Now &&
                                                                                           cover.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.CoverPrice).DefaultIfEmpty().Single())
                                          * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 3 ? s.ProductCountWastage :
                                         s.OperationType == 4 ? -s.ProductCountWastage : 0)),



                                            TotalWastageSalePrice = (lstPriceList.Where(sales => sales.ActionDate <= DateTime.Now &&
                                                                                           sales.ProductID == p.ProductID)
                                                                                 .OrderByDescending(o => o.ActionDate).Take(1)
                                                                                 .Select(s => s.SalesPrice).DefaultIfEmpty().Single())
                                         * (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 3 ? s.ProductCountWastage :
                                         s.OperationType == 4 ? -s.ProductCountWastage : 0)),

                                            TotalWastageProductCount = (StockList.Where(s => s.ProductID == p.ProductID).
                                          Sum(s => s.OperationType == 3 ? s.ProductCountWastage :
                                         s.OperationType == 4 ? -s.ProductCountWastage : 0))

                                        });

            return lstProductRialiStock.ToList();
        }
    }
}
