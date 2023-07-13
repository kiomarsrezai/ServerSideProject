using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetailEdit
    {
        public int Id { get; set; }

        public int? BudgetDetailId { get; set; }

        public long? Decrease { get; set; }

        public long? Increase { get; set; }

        public byte? StatusId { get; set; }

        public virtual TblBudgetDetail BudgetDetail { get; set; }
    }
}