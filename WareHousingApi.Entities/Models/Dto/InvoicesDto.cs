using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models.Dto
{
    public class InvoiceListDto
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TotalInvoicePrice { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerAddress { get; set; }
        public string InvoiceNo { get; set; }
        public byte InvoiceType { get; set; }
        public int FiscalYearID { get; set; }
        public byte InvoiceStatus { get; set; }
        public DateTime ReturnInvoiceDateTime { get; set; }
    }

    public class ReturnInvoiceDto
    {
        public int InvoiceID { get; set; }
        public int FiscalYearID { get; set; }
        public string UserID { get; set; }
    }

    public class SetInvoiceToCloseDto
    {
        public int InvoiceID { get; set; }
        public int FiscalYearID { get; set; }
        public string UserID { get; set; }
    }

    public class InvoiceDetailsPrintDto
    {
        public int InvoiceID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceTotalPrice { get; set; }
        public List<InvoiceItemForPrint> ItemList { get; set; }
    }

    public class InvoiceItemForPrint
    {
        public int ProductID { get; set; }
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }

    public class IndeedParameterForAllProduct
    {
        public int WareHouseID { get; set; }
        public int FiscalYearID { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }

    public class AllProductInvoicedDto
    {
        public int ProductID { get; set;}
        public int ProductCount { get; set;}
        public string ProductName { get; set;}
        public string ProductCode { get; set;}
        public DateTime ExpireDate { get; set;}
    }

    public class IndeedParameterGroupInvoiceDto
    {
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int WareHouseID { get; set; }
        public int FiscalYearID { get; set; }
    }

    public class GroupInvoiceDto
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public int ProductID { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
