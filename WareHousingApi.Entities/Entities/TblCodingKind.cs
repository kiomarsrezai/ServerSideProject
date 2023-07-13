using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCodingKind
    {
        public int Id { get; set; }

        public string CodingKindName { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}