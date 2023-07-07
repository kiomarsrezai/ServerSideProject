using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Models
{
    public class CountryEditViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "نام کشور وارد نشده است")]
        public string CountryName { get; set; }
        public int CountryID { get; set; }
    }
}
