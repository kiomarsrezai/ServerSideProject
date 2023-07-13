using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadStatus
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<TblSanad> TblSanads { get; } = new List<TblSanad>();
    }
}