using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetEdit
{
    public class BudgetEditUpdateParamViewModel
    {
        public int Id { get; set; }
        public Int64 Decrease { get; set; }
        public Int64 Increase { get; set; }
    }
}
