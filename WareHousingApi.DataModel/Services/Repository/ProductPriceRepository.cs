using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class ProductPriceRepository :UnitOfWork, IProductPriceRepository
    {

        public ProductPriceRepository(ApplicationDbContext context) :  base(context)
        {
        
        }

        public List<ProductPriceList> GetProductPriceList()
        {
            var lstPriceList = this.productPriceUW.Get().AsEnumerable();
            //
            var lstProductPrice = (from p in this.productUW.Get().ToList()
                                   select new ProductPriceList
                                   {
                                       ProductID = p.ProductID,
                                       ProductName = p.ProductName,
                                       ProductCode = p.ProductCode,
                                       PurchasePrice = lstPriceList.Where(purchase => purchase.ActionDate <= DateTime.Now &&
                                                                                      purchase.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.PurchasePrice).DefaultIfEmpty().Single(),
                                       CoverPrice = lstPriceList.Where(cover => cover.ActionDate <= DateTime.Now &&
                                                                                      cover.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.CoverPrice).DefaultIfEmpty().Single(),
                                       SalesPrice = lstPriceList.Where(sales => sales.ActionDate <= DateTime.Now &&
                                                                                      sales.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.SalesPrice).DefaultIfEmpty().Single(),
                                       ActionDate = lstPriceList.Where(action => action.ActionDate <= DateTime.Now &&
                                                                                      action.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.ActionDate).DefaultIfEmpty().Single(),
                                       ProductPriceID = lstPriceList.Where(id => id.ActionDate <= DateTime.Now &&
                                                                                      id.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.ProductPriceID).DefaultIfEmpty().Single(),
                                       UserID = lstPriceList.Where(user => user.ActionDate <= DateTime.Now &&
                                                                                      user.ProductID == p.ProductID)
                                                                            .OrderByDescending(o => o.ActionDate).Take(1)
                                                                            .Select(s => s.UserID).DefaultIfEmpty().Single(),
                                   });

            return lstProductPrice.ToList();
        }
    }
}
