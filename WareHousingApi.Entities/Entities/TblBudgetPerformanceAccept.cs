using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetPerformanceAccept
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? MonthId { get; set; }

        public virtual ICollection<TblBudgetPerformanceAcceptDetail> TblBudgetPerformanceAcceptDetails { get; } = new List<TblBudgetPerformanceAcceptDetail>();

        public virtual TblYear Year { get; set; }
    }
}