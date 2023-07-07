using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class ProductPriceCreateModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "قیمت خرید نباید خالی باشد.")]
        public int PurchasePrice { get; set; }
        //قیمت فروش به عمده فروش یا فروشگاه
        [Required(AllowEmptyStrings = false,ErrorMessage = "قیمت فروش نباید خالی باشد.")]
        public int SalesPrice { get; set; }
        //قیمت روی جلد - قیمت مصرف کننده
        [Required(AllowEmptyStrings = false, ErrorMessage = "قیمت مصرف کننده نباید خالی باشد.")]
        public int CoverPrice { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public int FiscalYearID { get; set; }
        //تاریخ اعمال قیمت
        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ اعمال قیمت نباید خالی باشد.")]
        public string ActionDate { get; set; }
    }

    public class ProductPriceList
    {
        public int ProductPriceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int FiscalYearID { get; set; }
        public string? UserID { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
