using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities
{
    public class Inventories_Tbl : FieldPublicInherits
    {
        [Key]
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int WareHouseID { get; set; }
        
        public int FiscalYearID { get; set; }
        //تعداد تراکنش در انبار اصلی
        public int ProductCountMain { get; set; }
        //تعداد تراکنش در انبار ضایعات
        public int ProductCountWastage { get; set; }

        //نوع عملیات
        //1 =  اضافه به انبار اصلی+
        //2 = کسر از انبار اصلی -
        //3 = اضافه به انبار ضایعات +
        //4 = کسر از انبار ضایعات -
        //5 = فروش -
        //6 = مرجوعی +
        //7 = بالانس افزایشی +
        //8 = بالانس کاهشی -
        //9 = انتقالی از سال مالی جدید
        public byte OperationType { get; set; }
        //تاریخ انقضا
        public DateTime ExpireDate { get; set; }
        //تاریخ انجام عملیات
        public DateTime OperationDate { get; set; }
        public string Description { get; set; }
        public int RefferenceID { get; set; }
        public int ProductLocationID { get; set; }
        public int InvoiceID { get; set; }
        //
        [ForeignKey("ProductID")]
        public virtual Products_Tbl Products { get; set; }
        [ForeignKey("WareHouseID")]
        public virtual WareHouses_Tbl WareHouse { get; set; }
        [ForeignKey("FiscalYearID")]
        public virtual FiscalYears_Tbl FiscalYear { get; set; }
        [ForeignKey("ProductLocationID")]
        public virtual ProductLocations_Tbl ProductLocations_Tbl { get; set; }
    }
}
