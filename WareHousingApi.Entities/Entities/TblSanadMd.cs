using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadMd
    {
        public long? Id { get; set; }

        public long? AreaId { get; set; }

        public int? YearName { get; set; }

        public DateTime? SanadDate { get; set; }

        public string SanadDateS { get; set; }

        public long? IdSanadkind { get; set; }

        public long? IdSanadState { get; set; }

        public string DescSanadMd { get; set; }
    }
}