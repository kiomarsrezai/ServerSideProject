using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateProjectEstimate
    {
        public int Id { get; set; }

        public int? EstateProjectId { get; set; }

        public string KindEstimateId { get; set; }

        public string Date { get; set; }

        public string Number { get; set; }

        public virtual TblEstateProject EstateProject { get; set; }
    }
}