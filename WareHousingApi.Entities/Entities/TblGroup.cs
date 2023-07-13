using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblGroup
    {
        public int? Id { get; set; }

        public int? IdRecognition { get; set; }

        public int? IdKind { get; set; }

        public int? AreaId { get; set; }

        public int? YearName { get; set; }

        public string Name { get; set; }
    }
}