using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class UserLoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is empty !!!")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is empty !!!")]
        public string Password { get; set; }
        public int FiscalYear { get; set; }
    }

    public class UserJwtToken
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public IList<string>? Roles { get; set; }
        public byte FiscalYearFlag { get; set; }
    }
}
