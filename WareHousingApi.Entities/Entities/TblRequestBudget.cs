using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblRequestBudget
    {
        public int Id { get; set; }

        public int? RequestId { get; set; }

        public int? BudgetDetailProjectAreaId { get; set; }

        public long? RequestBudgetAmount { get; set; }

        public string BodgetId { get; set; }

        public string BodgetDesc { get; set; }

        public int? Sal { get; set; }

        public int? AreaId { get; set; }

        public virtual TblBudgetDetailProjectArea BudgetDetailProjectArea { get; set; }

        public virtual TblRequest Request { get; set; }
    }
}
