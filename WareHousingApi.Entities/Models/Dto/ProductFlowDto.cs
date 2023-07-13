using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models.Dto
{
    public class ProductFlowResponseDto
    {
        public int WareHouseID { get; set; }
        public int ProductID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int FiscalYearID { get; set; }
    }

    public class ProductFlowReplyDto
    {
        //نوع عملیات
        public byte OpertaionType { get; set; }
        //تاریخ انقضا
        public DateTime ExpireDate { get; set; }
        //تاریخ انجام عملیات
        public DateTime OperationDate { get; set; }
        //تعداد تراکنش کالا در انبار اصلی
        public int ProductCountMain { get; set; }
        //تعداد تراکنش کالا در انبار ضایعات
        public int ProductCountWastage { get; set; }
        //توضیحات
        public string Description { get; set; }
        //کاربر ثبت کننده
        public string UserFullName { get; set; }
    }
}
