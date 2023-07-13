using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities
{
    public class FiscalYearCreateModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Start Date Can not be null !!")]
        public string StartDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "End Date Can not be null !!")]
        public string EndDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description Can not be null !!")]
        public string FiscalYearDescription { get; set; }

        public string UserID { get; set; }
    }

    public class FiscalYearEditModel
    {

        //public int id { get; set; }
        public int FiscalYearID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Start Date Can not be null !!")]
        public string StartDateE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "End Date Can not be null !!")]
        public string EndDateE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description Can not be null !!")]
        public string FiscalYearDescriptionE { get; set; }

        public string UserIDE { get; set; }
    }

    public class CloseFiscalModel
    {
        public int warehouseid { get; set; }
        public string userid { get; set; }
        public int fiscalyearid { get; set; }
    }
}