using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IInventoryRepository
    {
        List<InventoryStockModel> GetProductStock(InventoryQueryMaker model);
        int GetPhysicalStockForBranch(int InventoryID);
        int GetPhysicalWastageStockForBranch(int InventoryID);
        int GetOneProductStock(int ProductID, int WareHouseID, int FiscalYearID);
        List<ProductListExpireOrinted> ProductListExpireOriented(InventoryQueryMaker model);

        void TransferToNewFiscalYearRepo(CloseFiscalModel model);
    }
}