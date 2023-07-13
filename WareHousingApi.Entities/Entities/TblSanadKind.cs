using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadKind
    {
        public int Id { get; set; }

        public string KindName { get; set; }

        public virtual ICollection<TblSanad> TblSanads { get; } = new List<TblSanad>();
    }
}