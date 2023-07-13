using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models.Dto
{
    public class WastageRialiStock
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        //موجودی تعدادی
        public int TotalWastageProductCount { get; set; }
        //موجودی ریالی کل کالا - خرید
        public int TotalWastagePurchPrice { get; set; }
        //موجودی ریالی کل کالا - فروش
        public int TotalWastageSalePrice { get; set; }
        //موجودی ریالی کل کالا - مصرف کننده
        public int TotalWastageCoverPrice { get; set; }
    }

    public class WastageRialiStockArguman
    {
        public int FiscalYearID { get; set; }
        public int WareHouseID { get; set; }
    }
}
