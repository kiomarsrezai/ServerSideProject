using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCodingSubject
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}