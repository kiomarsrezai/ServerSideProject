using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadState
    {
        public long? Id { get; set; }

        public long? AreaId { get; set; }

        public int? YearName { get; set; }

        public string Name { get; set; }
    }
}