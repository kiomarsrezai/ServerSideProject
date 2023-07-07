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
    public class Countries_Tbl : FieldPublicInherits
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
