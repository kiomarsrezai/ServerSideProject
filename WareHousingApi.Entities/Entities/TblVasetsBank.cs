using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVasetsBank
    {
        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string IdTafsily4 { get; set; }

        public string NameTafsily { get; set; }

        public long? Expense { get; set; }
    }
}