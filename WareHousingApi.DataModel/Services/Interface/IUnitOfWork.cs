using Microsoft.AspNetCore.Mvc;
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
        GenericCRUDClass<Country> countryUW { get; }
        GenericCRUDClass<Supplier> supplierUW { get; }
        GenericCRUDClass<Product> productUW { get; }
        GenericCRUDClass<FiscalYear> fiscalYearUW { get; }
        GenericCRUDClass<WareHouse> wareHouseUW { get; }
        GenericCRUDClass<Inventory> inventoryUW { get; }
        GenericCRUDClass<ProductPrice> productPriceUW { get; }
        GenericCRUDClass<ProductLocation> productLocationUW { get; }
        GenericCRUDClass<UserInWareHouse> userInWareHouseUW { get; }
        GenericCRUDClass<Customer> customerUW { get; }
        GenericCRUDClass<InvoiceItem> invoicesItemsUW { get; }
        GenericCRUDClass<Invoice> invoicesUW { get; }
        void Save();
        Task SaveAsync();

        IEntityTransaction BeginTransaction();
    }
}