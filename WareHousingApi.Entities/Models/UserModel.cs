using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class UserCreateModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربر وارد نشده است.")]
        public string FirstNameC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "فامیل کاربر وارد نشده است.")]
        public string FamilyC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تصویر کاربر وارد نشده است.")]
        public string UserImageC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره ملی وارد نشده است.")]
        public string MelliCodeC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کد پرسنلی وارد نشده است.")]
        public string PersonalCodeC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد وارد نشده است.")]
        public string BirthDayDateC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " نام کاربری وارد نشده است.")]
        public string UserNameC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " شماره تماس وارد نشده است.")]
        public string PhoneNumberC { get; set; }

        public bool GenderC { get; set; }
        //1 = Admin
        //2 = User
        public byte UserTypeC { get; set; }
        public int[] UserInWareHouseIDC { get; set; }
        //آیدی کاربری که اطلاعات را ثبت می کند
        public string UserID { get; set; }
    }

    public class UserEditModel
    {
        //کاربری که اطلاعات را ثبت می کند
        public string UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربر وارد نشده است.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "فامیل کاربر وارد نشده است.")]
        public string Family { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تصویر کاربر وارد نشده است.")]
        public string UserImage { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره ملی وارد نشده است.")]
        public string MelliCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "کد پرسنلی وارد نشده است.")]
        public string PersonalCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد وارد نشده است.")]
        public string BirthDayDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " شماره تماس وارد نشده است.")]
        public string PhoneNumber { get; set; }

        public bool Gender { get; set; }
        public int[] UserInWareHouseID { get; set;}
        //کاربری که اطلاعاتش در حال ویرایش است
        public string UserIDWareHouse { get; set; }
    }

    public class UserAccessModel
    {
        public string CreateInvoice { get; set; }
        public string InvoiceList { get; set; }
        public string AllProductInvoiced { get; set; }
        public string InvoiceSeparation { get; set; }
        public string WareHousingHandle { get; set; }
        public string Inventory { get; set; }
        public string RiallyStock { get; set; }
        public string WastageRiallyStock { get; set; }
        public string ProductFlow { get; set; }
        public string ProductLocation { get; set; }
        public string ProductPrice { get; set; }
        public string UserIdAccess { get; set; }
    }
}
