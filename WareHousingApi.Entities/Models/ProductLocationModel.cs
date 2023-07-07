using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class ProductLocationCreateModel
    {
        public int WareHouseID { get; set; }
        public string UserID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام محل استقرار نباید خالی باشد.")]
        public string ProductLocationAddress { get; set; }
    }

    public class ProductLocationEditModel
    {
        public int ProductLocationID { get; set; }
        public int WareHouseIDE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "نام محل استقرار نباید خالی باشد.")]
        public string ProductLocationAddressE { get; set; }
    }
}
