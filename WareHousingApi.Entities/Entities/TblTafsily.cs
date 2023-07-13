using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblTafsily
    {
        public long? Id { get; set; }

        public long? IdSotooh { get; set; }

        public long? AreaId { get; set; }

        public int? YearName { get; set; }

        public long? IdTafsilyGroup { get; set; }

        public string Name { get; set; }

        public int? IdTafsilyType { get; set; }
    }
}