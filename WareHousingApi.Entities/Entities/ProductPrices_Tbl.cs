using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities
{
    public class ProductPrices_Tbl : FieldPublicInherits
    {
        [Key]
        public int ProductPriceID { get; set; }
        //قیمت خرید از تولیدکننده
        //-2,147,483,648 to 2,147,483,647
        public int PurchasePrice { get; set; }
        //قیمت فروش به عمده فروش یا فروشگاه
        public int SalesPrice { get; set; }
        //قیمت روی جلد - قیمت مصرف کننده
        public int CoverPrice { get; set; }

        public int ProductID { get; set; }

        public int FiscalYearID { get; set; }
        //تاریخ اعمال قیمت
        public DateTime ActionDate { get; set; }

        //
        [ForeignKey("FiscalYearID")]
        public virtual FiscalYears_Tbl   FiscalYear { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products_Tbl Products { get; set; }
    }
}