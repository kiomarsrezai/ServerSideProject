using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Repository;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericCRUDClass<ApplicationUsers> userManagerUW { get; }
        GenericCRUDClass<ApplicationRoles> roleManagerUW { get; }
        GenericCRUDClass<Countries_Tbl> countryUW { get; }
        GenericCRUDClass<TblDepartman> departmentUW { get; }
        GenericCRUDClass<Suppliers_Tbl> supplierUW { get; }
        GenericCRUDClass<Products_Tbl> productUW { get; }
        GenericCRUDClass<FiscalYears_Tbl> fiscalYearUW { get; }
        GenericCRUDClass<WareHouses_Tbl> wareHouseUW { get; }
        GenericCRUDClass<Inventories_Tbl> inventoryUW { get; }
        GenericCRUDClass<ProductPrices_Tbl> productPriceUW { get; }
        GenericCRUDClass<ProductLocations_Tbl> productLocationUW { get; }
        GenericCRUDClass<UserInWareHouse_Tbl> userInWareHouseUW { get; }
        GenericCRUDClass<Customers_Tbl> customerUW { get; }
        GenericCRUDClass<InvoiceItems_Tbl> invoicesItemsUW { get; }
        GenericCRUDClass<Invoices_Tbl> invoicesUW { get; }
        GenericCRUDClass<TblRequest> requestUW { get; }
        GenericCRUDClass<TblRequestTable> requestItemUW { get; }
        void Save();
        void SaveAsync();

        IEntityTransaction BeginTransaction();
    }
}