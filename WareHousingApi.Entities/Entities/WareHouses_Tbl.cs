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
    public class WareHouses_Tbl : FieldPublicInherits
    {
        [Key]
        public int WareHouseID { get; set; }
        public string WareHouseName { get; set; }
        public string WareHouseAddress { get; set; }
        public string WareHouseTel { get; set; }

    }
}