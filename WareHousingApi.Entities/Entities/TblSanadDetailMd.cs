using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadDetailMd
    {
        public long? Id { get; set; }

        public long? IdSanadMd { get; set; }

        public long? IdSalSanadMd { get; set; }

        public long? AreaId { get; set; }

        public int? YearName { get; set; }

        public string IdKol { get; set; }

        public string IdMoien { get; set; }

        public string IdTafsily4 { get; set; }

        public string CodeVasetSazman { get; set; }

        public long? IdSotooh4 { get; set; }

        public string IdTafsily5 { get; set; }

        public long? IdSotooh5 { get; set; }

        public string CodeVasetShahrdari { get; set; }

        public string IdTafsily6 { get; set; }

        public long? IdSotooh6 { get; set; }

        public string Description { get; set; }

        public long? Bedehkar { get; set; }

        public long? Bestankar { get; set; }
    }
}