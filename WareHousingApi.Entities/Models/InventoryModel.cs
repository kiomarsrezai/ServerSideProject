using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class InventoryStockModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalProductCount { get; set; }
        public int TotalProductWaste { get; set; }
    }

    public class InventoryQueryMaker
    {
        public int FiscalYearID { get; set; }
        public int WareHouseID { get; set; }
    }

    public class AddStockModel
    {
        public int ProductID { get; set; }
        public int WareHouseID { get; set; }

        public int FiscalYearID { get; set; }
        //تعداد تراکنش در انبار اصلی
        [Required(AllowEmptyStrings = false)]
        [Range(1, int.MaxValue)]
        public int ProductCountMain { get; set; }

        //نوع عملیات
        //1 =  اضافه به انبار اصلی+
        //2 = کسر از انبار اصلی -
        //3 = اضافه به انبار ضایعات +
        //4 = کسر از انبار ضایعات -
        //5 = فروش -
        //6 = مرجوعی +
        //7 = بالانس افزایشی +
        //8 = بالانس کاهشی -
        public byte OperationType { get; set; }
        //تاریخ انقضا
        [Required(AllowEmptyStrings = false)]
        public string ExpireDate { get; set; }
        //تاریخ انجام عملیات
        [Required(AllowEmptyStrings = false)]
        public string OperationDate { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public int ProductLocationID { get; set; }
        
        public string BalanceStockAdd { get; set; }
    }

    public class ExitStockModel
    {
        public int ProductIDE { get; set; }
        public int WareHouseIDE { get; set; }

        public int FiscalYearIDE { get; set; }
        //تعداد تراکنش در انبار اصلی
        [Required(AllowEmptyStrings = false)]
        [Range(1, int.MaxValue)]
        public int ProductCountMainE { get; set; }

        //نوع عملیات
        //1 =  اضافه به انبار اصلی+
        //2 = کسر از انبار اصلی -
        //3 = اضافه به انبار ضایعات +
        //4 = کسر از انبار ضایعات -
        //5 = فروش -
        //6 = مرجوعی +
        //7 = بالانس افزایشی +
        //8 = بالانس کاهشی -
        public byte OperationType { get; set; }
        //تاریخ انقضا
        //[Required(AllowEmptyStrings = false)]
        //public string ExpireDateE { get; set; }
        //تاریخ انجام عملیات
        [Required(AllowEmptyStrings = false)]
        public string OperationDateE { get; set; }
        public string DescriptionE { get; set; }
        public string UserIDE { get; set; }
        public int ReffernceInvID { get; set; }
        public string BalanceStockRemove { get; set; }
    }

    public class WastageStockModel
    {
        public int ProductIDWastage { get; set; }
        public int WareHouseIDWastage { get; set; }

        public int FiscalYearIDWastage { get; set; }
        //تعداد تراکنش در انبار اصلی
        [Required(AllowEmptyStrings = false)]
        [Range(1, int.MaxValue)]
        public int ProductCountWastage { get; set; }

        //نوع عملیات
        //1 =  اضافه به انبار اصلی+
        //2 = کسر از انبار اصلی -
        //3 = اضافه به انبار ضایعات +
        //4 = کسر از انبار ضایعات -
        //5 = فروش -
        //6 = مرجوعی +
        public byte OperationType { get; set; }
        //تاریخ انقضا
        //[Required(AllowEmptyStrings = false)]
        //public string ExpireDateE { get; set; }
        //تاریخ انجام عملیات
        [Required(AllowEmptyStrings = false)]
        public string OperationDateWastage { get; set; }
        public string DescriptionWastage { get; set; }
        public string UserIDWastage { get; set; }
        public int ReffernceInvIDWastage { get; set; }
    }

    public class BackWastageStockModel
    {
        public int ProductIDBackWastage { get; set; }
        public int WareHouseIDBackWastage { get; set; }

        public int FiscalYearIDBackWastage { get; set; }
        //تعداد تراکنش در انبار اصلی
        [Required(AllowEmptyStrings = false)]
        [Range(1, int.MaxValue)]
        public int ProductCountBackWastage { get; set; }

        //نوع عملیات
        //1 =  اضافه به انبار اصلی+
        //2 = کسر از انبار اصلی -
        //3 = اضافه به انبار ضایعات +
        //4 = کسر از انبار ضایعات -
        //5 = فروش -
        //6 = مرجوعی +
        public byte OperationType { get; set; }
        //تاریخ انقضا
        //[Required(AllowEmptyStrings = false)]
        //public string ExpireDateE { get; set; }
        //تاریخ انجام عملیات
        [Required(AllowEmptyStrings = false)]
        public string OperationDateBackWastage { get; set; }
        public string DescriptionBackWastage { get; set; }
        public string UserIDBackWastage { get; set; }
        public int ReffernceInvIDBackWastage { get; set; }
    }

    public class ProductListExpireOrinted
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class ProductListExpireOrinted2
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public int InventoryID { get; set; }
    }

    //بستن سال مالی
    public class TransferToNewFiscalYearDto2
    {
        public int ProductID { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public int InventoryID { get; set; }
    }

    public class TransferToNewFiscalYearDto
    {
        public int ProductID { get; set; }
        public int TotalProductCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}