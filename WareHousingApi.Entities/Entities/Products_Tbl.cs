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
    public class Products_Tbl : FieldPublicInherits
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public PackingType PackingType { get; set; }
        public int CountInPacking { get; set; }
        public int ProductWeight { get; set; }
        public string ProductImage { get; set; }
        public int SupplierID { get; set; }
        public int CountryID { get; set; }

        //1 = یخچالی
        //2 = غیریخچالی
        public byte IsRefregerator { get; set; }
     
        #region Relation
        [ForeignKey("SupplierID")]
        public virtual Suppliers_Tbl Supplier { get; set; }
        [ForeignKey("CountryID")]
        public virtual Countries_Tbl Country { get; set; }
        #endregion
    }


    public enum PackingType
    {
        Shell = 1,
        Cartoon = 2,
        Box = 3,
        BreakingPacking = 4
    }
}