using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVaset
    {
        public int VasetId { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string IdTafsily4 { get; set; }

        public string IdTafsily5 { get; set; }

        public string NameTafsily { get; set; }

        public string Markhazhazine { get; set; }

        public long? Supply { get; set; }

        public long? Takhsis { get; set; }

        public long? Expense { get; set; }

        public string CodeVaset { get; set; }
    }
}