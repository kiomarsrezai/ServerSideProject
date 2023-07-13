using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Models;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IInvoiceRepository
    {
        ProductItemDto GetProductItemInfo(string productcode, int warehouseid, int fiscalyearid);
        int GetPurchasePrice(int productid);
        int GetSalesPrice(int productid);
        int GetCoverPrice(int productid);
        int CalculateInvoicePrice(int[] productid, int[] productcount, int fiscalyearid);
        List<InvoiceListDto> InvoiceListFullInfo(RecieveParametersInvoiceList model);
        List<InvoiceItemListViewModel> GetInvoiceItemList(int InvoiceID);
        InvoiceDetailsPrintDto GetInvoiceDetailsFunc(int InvoiceID);
        List<AllProductInvoicedDto> AllProductInvoicedRepo(IndeedParameterForAllProduct model);
        List<GroupInvoiceDto> GroupInvoiceRepo(IndeedParameterGroupInvoiceDto model);
    }
}
