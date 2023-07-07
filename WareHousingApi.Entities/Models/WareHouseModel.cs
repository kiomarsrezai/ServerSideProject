using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class WareHouseCreateModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseTel { get; set; }

        public string UserID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }


    public class WareHouseEditModel
    {
        public int WareHouseID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseNameE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseAddressE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} must not be empty !!! ")]
        public string WareHouseTelE { get; set; }

        //public string UserID { get; set; }
        //public DateTime CreateDateTime { get; set; }
    }
}
