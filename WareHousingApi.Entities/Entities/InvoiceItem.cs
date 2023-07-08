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
    public class InvoiceItem : FieldPublicInherits
    {
        [Key]
        public int InvoiceItemID { get; set; }
        public int ProductID { get; set; }
        public int ProductCount { get; set; }
        public int InvoiceID { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
        //
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
        [ForeignKey("InvoiceID")]
        public virtual Invoice Invoices { get; set; }
    }
}
