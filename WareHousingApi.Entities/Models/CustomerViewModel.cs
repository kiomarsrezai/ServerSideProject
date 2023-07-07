using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models
{
    public class CreateCustomerViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام مشتری وارد نشده است.")]
        public string CustomerFullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره تماس مشتری وارد نشده است.")]
        public string CustomerTel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "آدرس مشتری وارد نشده است.")]
        public string CustomerAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کد ملی/کد اقتصادی مشتری وارد نشده است.")]
        public string EconomicCode { get; set; }
        public string UserID { get; set; }
        public int WareHouseID { get; set; }
    }

    public class EditCustomerViewModel
    {
        public int CustomerID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام مشتری وارد نشده است.")]
        public string CustomerFullNameE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره تماس مشتری وارد نشده است.")]
        public string CustomerTelE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "آدرس مشتری وارد نشده است.")]
        public string CustomerAddressE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کد ملی/کد اقتصادی مشتری وارد نشده است.")]
        public string EconomicCodeE { get; set; }
        public int WareHouseIDE { get; set; }
    }
}
