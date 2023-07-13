using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities.Entities
{
    public class Invoices_Tbl : FieldPublicInherits
    {
        [Key]
        public int InvoiceID { get; set; }
        public int WareHouseID { get; set; }
        public int CustomerID { get; set; }
        //1 = فروش
        //2 = مرجوعی
        public byte InvoiceType { get; set; }
        public int InvoiceTotalPrice { get; set; }
        //1 = فاکتور بسته
        //2 = فاکتور موقت - پیش فاکتور
        public byte InvoiceStatus { get; set; }
        public string InvoiceNo { get; set; }
        public int FiscalYearID { get; set; }

        public DateTime? ReturnInvoiceDateTime { get; set; }
        //
        [ForeignKey("WareHouseID")]
        public virtual WareHouses_Tbl WareHouses { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customers_Tbl Customers { get; set; }
        [ForeignKey("FiscalYearID")]
        public virtual FiscalYears_Tbl FiscalYears_Tbl { get; set; }
    }
}
