using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanad
    {
        public int Id { get; set; }

        public int? YearFinancialId { get; set; }

        public int? SanadKindId { get; set; }

        public int? SanadStatusId { get; set; }

        public int? Number { get; set; }

        public DateTime? Date { get; set; }

        public string DateS { get; set; }

        public string Description { get; set; }

        public virtual TblSanadKind SanadKind { get; set; }

        public virtual TblSanadStatus SanadStatus { get; set; }

        public virtual ICollection<TblSanadDetail> TblSanadDetails { get; } = new List<TblSanadDetail>();

    }
}