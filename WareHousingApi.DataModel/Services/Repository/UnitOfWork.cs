using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private GenericCRUDClass<ApplicationUsers> _userManager;
        private GenericCRUDClass<ApplicationRoles> _roleManager;
        private GenericCRUDClass<Products_Tbl> _product;
        private GenericCRUDClass<Suppliers_Tbl> _supplier;
        private GenericCRUDClass<Countries_Tbl> _country;
        private GenericCRUDClass<TblDepartman> _departmet;
        private GenericCRUDClass<FiscalYears_Tbl> _fiscalYear;
        private GenericCRUDClass<WareHouses_Tbl> _wareHouse;
        private GenericCRUDClass<Inventories_Tbl> _inventory;
        private GenericCRUDClass<ProductPrices_Tbl> _productPrice;
        private GenericCRUDClass<ProductLocations_Tbl> _productLocation;
        private GenericCRUDClass<UserInWareHouse_Tbl> _userInWareHouse;
        private GenericCRUDClass<Customers_Tbl> _customer;
        private GenericCRUDClass<Invoices_Tbl> _invoices;
        private GenericCRUDClass<InvoiceItems_Tbl> _invoicesItems;
        private GenericCRUDClass<TblRequest> _request;
        private GenericCRUDClass<TblRequestTable> _requestItem;

        //لیست دپارتممان ها
        public GenericCRUDClass<TblDepartman> departmentUW
        {
            //فقط خواندنی
            get
            {
                if (_departmet == null)
                {
                    _departmet = new GenericCRUDClass<TblDepartman>(_context);
                }
                return _departmet;
            }
        }
        //لیست اقلام فاکتورها
        public GenericCRUDClass<InvoiceItems_Tbl> invoicesItemsUW
        {
            //فقط خواندنی
            get
            {
                if (_invoicesItems == null)
                {
                    _invoicesItems = new GenericCRUDClass<InvoiceItems_Tbl>(_context);
                }
                return _invoicesItems;
            }
        }
        //لیست فاکتورها
        public GenericCRUDClass<Invoices_Tbl> invoicesUW
        {
            //فقط خواندنی
            get
            {
                if (_invoices == null)
                {
                    _invoices = new GenericCRUDClass<Invoices_Tbl>(_context);
                }
                return _invoices;
            }
        }
        //لیست مشتریان هر انبار
        public GenericCRUDClass<Customers_Tbl> customerUW
        {
            //فقط خواندنی
            get
            {
                if (_customer == null)
                {
                    _customer = new GenericCRUDClass<Customers_Tbl>(_context);
                }
                return _customer;
            }
        }
        //لیست کاربران هر انبار
        public GenericCRUDClass<UserInWareHouse_Tbl> userInWareHouseUW
        {
            //فقط خواندنی
            get
            {
                if (_userInWareHouse == null)
                {
                    _userInWareHouse = new GenericCRUDClass<UserInWareHouse_Tbl>(_context);
                }
                return _userInWareHouse;
            }
        }
        //محل استقرار کالا در انبار
        public GenericCRUDClass<ProductLocations_Tbl> productLocationUW
        {
            //فقط خواندنی
            get
            {
                if (_productLocation == null)
                {
                    _productLocation = new GenericCRUDClass<ProductLocations_Tbl>(_context);
                }
                return _productLocation;
            }
        }
        //قیمت گذاری کالا
        public GenericCRUDClass<ProductPrices_Tbl> productPriceUW
        {
            //فقط خواندنی
            get
            {
                if (_productPrice == null)
                {
                    _productPrice = new GenericCRUDClass<ProductPrices_Tbl>(_context);
                }
                return _productPrice;
            }
        }
        //انبارداری
        public GenericCRUDClass<Inventories_Tbl> inventoryUW
        {
            //فقط خواندنی
            get
            {
                if (_inventory == null)
                {
                    _inventory = new GenericCRUDClass<Inventories_Tbl>(_context);
                }
                return _inventory;
            }
        }
        //لیست انبارها
        public GenericCRUDClass<WareHouses_Tbl> wareHouseUW
        {
            //فقط خواندنی
            get
            {
                if (_wareHouse == null)
                {
                    _wareHouse = new GenericCRUDClass<WareHouses_Tbl>(_context);
                }
                return _wareHouse;
            }
        }

        //سال مالی
        public GenericCRUDClass<FiscalYears_Tbl> fiscalYearUW
        {
            //فقط خواندنی
            get
            {
                if (_fiscalYear == null)
                {
                    _fiscalYear = new GenericCRUDClass<FiscalYears_Tbl>(_context);
                }
                return _fiscalYear;
            }
        }

        //کاربران
        public GenericCRUDClass<ApplicationUsers> userManagerUW
        {
            //فقط خواندنی
            get
            {
                if (_userManager == null)
                {
                    _userManager = new GenericCRUDClass<ApplicationUsers>(_context);
                }
                return _userManager;
            }
        }
        //نقش ها
        public GenericCRUDClass<ApplicationRoles> roleManagerUW
        {
            //فقط خواندنی
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericCRUDClass<ApplicationRoles>(_context);
                }
                return _roleManager;
            }
        }
        //کشور ها
        public GenericCRUDClass<Countries_Tbl> countryUW
        {
            //فقط خواندنی
            get
            {
                if (_country == null)
                {
                    _country = new GenericCRUDClass<Countries_Tbl>(_context);
                }
                return _country;
            }
        }
        //تامین کنندگان
        public GenericCRUDClass<Suppliers_Tbl> supplierUW
        {
            //فقط خواندنی
            get
            {
                if (_supplier == null)
                {
                    _supplier = new GenericCRUDClass<Suppliers_Tbl>(_context);
                }
                return _supplier;
            }
        }
        //کالاها
        public GenericCRUDClass<Products_Tbl> productUW
        {
            //فقط خواندنی
            get
            {
                if (_product == null)
                {
                    _product = new GenericCRUDClass<Products_Tbl>(_context);
                }
                return _product;
            }
        }

        public GenericCRUDClass<TblRequest> requestUW 
        {
            get
            {
                if (_request == null)
                {
                    _request = new GenericCRUDClass<TblRequest>(_context);
                }
                return _request;
            }
        }

        public GenericCRUDClass<TblRequestTable> requestItemUW
        {
            get
            {
                if (_requestItem == null)
                {
                    _requestItem = new GenericCRUDClass<TblRequestTable>(_context);
                }
                return _requestItem;
            }
        }

       // public GenericCRUDClass<TblRequestTable> requestItemUW => throw new NotImplementedException();

        public IEntityTransaction BeginTransaction()
        {
            return new EntityTransaction(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}