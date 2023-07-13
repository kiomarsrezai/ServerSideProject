using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetailProjectAreaEdit12345678910
    {
        public int Id { get; set; }

        public int? BudgetDetailProjectAreaId { get; set; }

        public long? Decrease { get; set; }

        public long? Increase { get; set; }

        public int? EditStatusId { get; set; }

        public virtual TblBudgetDetailProjectArea BudgetDetailProjectArea { get; set; }

        public virtual TblEditStatus EditStatus { get; set; }
    }
}