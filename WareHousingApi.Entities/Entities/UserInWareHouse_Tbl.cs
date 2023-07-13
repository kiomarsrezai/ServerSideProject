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
    public class UserInWareHouse_Tbl : FieldPublicInherits
    {
        [Key]
        public int UserInWareHouseID { get; set; }
        //آیدی کاربری که در انبار کار می کند
        public string UserIDInWareHouse { get; set; }
        public int WareHouseID { get; set; }
        //
        [ForeignKey("UserIDInWareHouse")]
        public virtual ApplicationUsers Users_WareHouse { get; set; }
        [ForeignKey("WareHouseID")]
        public virtual WareHouses_Tbl WareHouse { get; set; }
    }
}
