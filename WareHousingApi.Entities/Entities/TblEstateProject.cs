using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateProject
    {
        public int Id { get; set; }

        public int? EstateId { get; set; }

        public int? ProjectId { get; set; }

        public virtual ICollection<TblEstateProjectEstimate> TblEstateProjectEstimates { get; } = new List<TblEstateProjectEstimate>();
    }
}