using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommite
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? CommiteKindId { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string DateS { get; set; }

        public virtual TblCommiteKind CommiteKind { get; set; }

        public virtual ICollection<TblCommiteDetail> TblCommiteDetails { get; } = new List<TblCommiteDetail>();

        public virtual TblYear Year { get; set; }
    }
}