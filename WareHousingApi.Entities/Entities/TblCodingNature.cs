using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCodingNature
    {
        public int Id { get; set; }

        public string CodingNatureName { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}