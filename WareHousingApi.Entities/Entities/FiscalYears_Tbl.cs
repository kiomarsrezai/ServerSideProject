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
    public class FiscalYears_Tbl : FieldPublicInherits
    {
        [Key]
        public int FiscalYearID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FiscalYearDescription { get; set; }
        //True = سال مالی باز می باشد
        //False = سال مالی بسته می باشد
        public bool FiscalFlag { get; set; }

      
    }
}