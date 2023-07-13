using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEditStatus
    {
        public int Id { get; set; }

        public string DescriptionStatus { get; set; }

        public virtual ICollection<TblBudgetDetailProjectAreaEdit12345678910> TblBudgetDetailProjectAreaEdit12345678910s { get; } = new List<TblBudgetDetailProjectAreaEdit12345678910>();
    }
}