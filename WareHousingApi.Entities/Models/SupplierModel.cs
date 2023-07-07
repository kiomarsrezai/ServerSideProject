using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class SupplierCreateModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام تامین کننده وارد نشده است.")]
        public string SupplierName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تلفن تامین کننده وارد نشده است.")]
        public string SupplierTel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وب سایت تامین کننده وارد نشده است.")]
        public string Website { get; set; }
        public string UserID { get; set; }
    }

    public class SupplierEditModel
    {
        public int SupplierID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام تامین کننده وارد نشده است.")]
        public string SupplierName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "تلفن تامین کننده وارد نشده است.")]
        public string SupplierTel { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وب سایت تامین کننده وارد نشده است.")]
        public string Website { get; set; }
    }
}
