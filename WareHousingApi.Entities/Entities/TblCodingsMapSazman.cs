using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCodingsMapSazman
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public int? CodingId { get; set; }

        public string CodeAcc { get; set; }

        public string TitleAcc { get; set; }

        public byte? PercentBud { get; set; }

        public string CodeVasetShahrdari { get; set; }

        public int? YearName { get; set; }

        public virtual TblCoding Coding { get; set; }
    }
}