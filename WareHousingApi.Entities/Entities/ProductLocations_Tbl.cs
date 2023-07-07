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
    public class ProductLocations_Tbl : FieldPublicInherits
    {
        [Key]
        public int ProductLocationID { get; set; }
        public int WareHouseID { get; set; }
        public string ProductLocationAddress { get; set; }
        //
        [ForeignKey("WareHouseID")]
        public virtual WareHouses_Tbl WareHouse { get; set; }

    }
}
