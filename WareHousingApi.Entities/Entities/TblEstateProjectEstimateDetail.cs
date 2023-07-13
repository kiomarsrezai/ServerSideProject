using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateProjectEstimateDetail
    {
        public int Id { get; set; }

        public int? EstateProjectEstimateId { get; set; }

        public string LawDetailId { get; set; }

        public string Quality { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }
    }
}