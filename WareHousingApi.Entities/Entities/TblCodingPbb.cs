using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCodingPbb
    {
        public int Id { get; set; }

        public int? MotherId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public byte? LevelNumber { get; set; }

        public virtual ICollection<TblCodingPbb> InverseMother { get; } = new List<TblCodingPbb>();

        public virtual TblCodingPbb Mother { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}