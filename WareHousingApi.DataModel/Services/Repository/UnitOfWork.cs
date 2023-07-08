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
        private GenericCRUDClass<Product> _product;
        private GenericCRUDClass<Supplier> _supplier;
        private GenericCRUDClass<Country> _country;
        private GenericCRUDClass<FiscalYear> _fiscalYear;
        private GenericCRUDClass<WareHouse> _wareHouse;
        private GenericCRUDClass<Inventory> _inventory;
        private GenericCRUDClass<ProductPrice> _productPrice;
        private GenericCRUDClass<ProductLocation> _productLocation;
        private GenericCRUDClass<UserInWareHouse> _userInWareHouse;
        private GenericCRUDClass<Customer> _customer;
        private GenericCRUDClass<Invoice> _invoices;
        private GenericCRUDClass<InvoiceItem> _invoicesItems;

        //لیست اقلام فاکتورها
        public GenericCRUDClass<InvoiceItem> invoicesItemsUW
        {
            //فقط خواندنی
            get
            {
                if (_invoicesItems == null)
                {
                    _invoicesItems = new GenericCRUDClass<InvoiceItem>(_context);
                }
                return _invoicesItems;
            }
        }
        //لیست فاکتورها
        public GenericCRUDClass<Invoice> invoicesUW
        {
            //فقط خواندنی
            get
            {
                if (_invoices == null)
                {
                    _invoices = new GenericCRUDClass<Invoice>(_context);
                }
                return _invoices;
            }
        }
        //لیست مشتریان هر انبار
        public GenericCRUDClass<Customer> customerUW
        {
            //فقط خواندنی
            get
            {
                if (_customer == null)
                {
                    _customer = new GenericCRUDClass<Customer>(_context);
                }
                return _customer;
            }
        }
        //لیست کاربران هر انبار
        public GenericCRUDClass<UserInWareHouse> userInWareHouseUW
        {
            //فقط خواندنی
            get
            {
                if (_userInWareHouse == null)
                {
                    _userInWareHouse = new GenericCRUDClass<UserInWareHouse>(_context);
                }
                return _userInWareHouse;
            }
        }
        //محل استقرار کالا در انبار
        public GenericCRUDClass<ProductLocation> productLocationUW
        {
            //فقط خواندنی
            get
            {
                if (_productLocation == null)
                {
                    _productLocation = new GenericCRUDClass<ProductLocation>(_context);
                }
                return _productLocation;
            }
        }
        //قیمت گذاری کالا
        public GenericCRUDClass<ProductPrice> productPriceUW
        {
            //فقط خواندنی
            get
            {
                if (_productPrice == null)
                {
                    _productPrice = new GenericCRUDClass<ProductPrice>(_context);
                }
                return _productPrice;
            }
        }
        //انبارداری
        public GenericCRUDClass<Inventory> inventoryUW
        {
            //فقط خواندنی
            get
            {
                if (_inventory == null)
                {
                    _inventory = new GenericCRUDClass<Inventory>(_context);
                }
                return _inventory;
            }
        }
        //لیست انبارها
        public GenericCRUDClass<WareHouse> wareHouseUW
        {
            //فقط خواندنی
            get
            {
                if (_wareHouse == null)
                {
                    _wareHouse = new GenericCRUDClass<WareHouse>(_context);
                }
                return _wareHouse;
            }
        }

        //سال مالی
        public GenericCRUDClass<FiscalYear> fiscalYearUW
        {
            //فقط خواندنی
            get
            {
                if (_fiscalYear == null)
                {
                    _fiscalYear = new GenericCRUDClass<FiscalYear>(_context);
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
        public GenericCRUDClass<Country> countryUW
        {
            //فقط خواندنی
            get
            {
                if (_country == null)
                {
                    _country = new GenericCRUDClass<Country>(_context);
                }
                return _country;
            }
        }
        //تامین کنندگان
        public GenericCRUDClass<Supplier> supplierUW
        {
            //فقط خواندنی
            get
            {
                if (_supplier == null)
                {
                    _supplier = new GenericCRUDClass<Supplier>(_context);
                }
                return _supplier;
            }
        }
        //کالاها
        public GenericCRUDClass<Product> productUW
        {
            //فقط خواندنی
            get
            {
                if (_product == null)
                {
                    _product = new GenericCRUDClass<Product>(_context);
                }
                return _product;
            }
        }

        public IEntityTransaction BeginTransaction()
        {
            return new EntityTransaction(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}