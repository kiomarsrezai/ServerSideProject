using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models.Dto
{
    public class RialiStockDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        //موجودی تعدادی
        public int TotalProductCount { get; set; }
        //موجودی ریالی کل کالا - خرید
        public int TotalPurchPrice { get; set; }
        //موجودی ریالی کل کالا - فروش
        public int TotalSalePrice { get; set; }
        //موجودی ریالی کل کالا - مصرف کننده
        public int TotalCoverPrice { get; set; }

    }

    public class RialiStockArguman
    {
        public int FiscalYearID { get; set; }
        public int WareHouseID { get; set; }
    }
}
