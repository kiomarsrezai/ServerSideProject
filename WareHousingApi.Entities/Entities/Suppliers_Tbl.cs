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
    public class Suppliers_Tbl : FieldPublicInherits
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } 
        public string SupplierTel { get; set; } 
        public string Website { get; set; }
    }
}
