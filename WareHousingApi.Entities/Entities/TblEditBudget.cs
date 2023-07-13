using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEditBudget
    {
        public int Id { get; set; }

        public int? EditBudgetKindId { get; set; }

        public string Description { get; set; }
    }
}