using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVasetTarazSazman
    {
        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string AreaName { get; set; }

        public string IdKol { get; set; }

        public string IdMoien { get; set; }

        public string IdTafsily { get; set; }

        public string CodeAcc { get; set; }

        public string Title { get; set; }

        public long? Expense { get; set; }
    }
}