using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSign
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public virtual ICollection<TblSignDetail> TblSignDetails { get; } = new List<TblSignDetail>();
    }
}