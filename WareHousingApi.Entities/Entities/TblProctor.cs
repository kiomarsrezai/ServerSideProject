using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblProctor
    {
        public int Id { get; set; }

        public string ProctorName { get; set; }

        public string ProctorNameShort { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}