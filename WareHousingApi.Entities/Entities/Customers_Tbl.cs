using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities.Entities
{
    public class Customers_Tbl : FieldPublicInherits
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerAddress { get; set; }
        public string EconomicCode { get; set; }
        public int WareHouseID { get; set; }

        //
        [ForeignKey("WareHouseID")]
        public virtual WareHouses_Tbl WareHouses { get; set; }
    }
}
