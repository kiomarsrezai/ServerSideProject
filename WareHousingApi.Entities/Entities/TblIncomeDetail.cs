using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblIncomeDetail
    {
        public int? Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public int? IncomeId { get; set; }

        public int? CodingSemakId { get; set; }

        public long? Amount { get; set; }

        public string IdKol { get; set; }

        public string IdMoien { get; set; }

        public string IdTafsily4 { get; set; }

        public string IdTafsily5 { get; set; }
    }
}