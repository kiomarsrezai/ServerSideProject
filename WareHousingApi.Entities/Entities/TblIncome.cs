using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblIncome
    {
        public int? Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string ShSerialFish { get; set; }

        public string ShenaseGhabz { get; set; }

        public string SdateSodoor { get; set; }

        public long? MablaghKol { get; set; }

        public int? SanadMd { get; set; }

        public string SimakMalekName { get; set; }
    }
}