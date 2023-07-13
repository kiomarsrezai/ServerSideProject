using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models
{
    public class CreateInvoiceViewModel
    {
        [Required]
        public int warehouseid { get; set; }
        [Required]
        public int customerid { get; set; }
        [Required]
        public int fiscalyearid { get; set; }
        [Required]
        public string userid { get; set; }
        [Required]
        public int[] productid { get; set; }
        [Required]
        public int[] productcount { get; set; }
        public byte invoicestatus { get; set; }
    }

    public class RecieveParametersInvoiceList
    {
        public int WareHouseID { get; set; }
        public string UserID { get; set; }
        public int FiscalYearID { get; set; }
        public string FromDate { get; set; } = "1300/01/01";
        public string ToDate { get; set; } = "1600/01/01";
    }

    public class InvoiceItemListViewModel
    {
        public int ProductID { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int PurchasePrice { get; set; }
        public int SalesPrice { get; set; }
        public int CoverPrice { get; set; }
    }
}
