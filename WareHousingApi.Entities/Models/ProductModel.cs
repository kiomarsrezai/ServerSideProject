using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class ProductCreateModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کالا وارد نشده است.")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "کد کالا وارد نشده است.")]
        public string ProductCode { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = " نوع بسته بندی انتخاب نشده است.")]
        public PackingType PackingType { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تعداد کالا وارد نشده است.")]
        public int CountInPacking { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وزن کالا وارد نشده است.")]
        public int ProductWeight { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تصویر کالا وارد نشده است.")]
        public string ProductImage { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "تامین کننده انتخاب نشده است.")]
        public int SupplierID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "کشور انتخاب نشده است.")]
        public int CountryID { get; set; }

        //1 = یخچالی
        //2 = غیریخچالی
        public byte IsRefregerator { get; set; }
        public string UserID { get; set; }
    }

    public class ProductEditModel
    {
        public int ProductID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کالا وارد نشده است.")]
        public string ProductNameE { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "کد کالا وارد نشده است.")]
        public string ProductCodeE { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " نوع بسته بندی انتخاب نشده است.")]
        public PackingType PackingTypeE { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تعداد کالا وارد نشده است.")]
        public int CountInPackingE { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وزن کالا وارد نشده است.")]
        public int ProductWeightE { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تصویر کالا وارد نشده است.")]
        public string ProductImageE { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "تامین کننده انتخاب نشده است.")]
        public int SupplierIDE { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "کشور انتخاب نشده است.")]
        public int CountryIDE { get; set; }

        //1 = یخچالی
        //2 = غیریخچالی
        public byte IsRefregeratorE { get; set; }
    }
}
