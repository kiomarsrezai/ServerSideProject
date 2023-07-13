using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class BudgetModal1CodingInsertParamModel
    {
        public int CodingId { get; set; }
        public int areaId { get; set; }
        public int yearId { get; set; }
        public int BudgetProcessId { get; set; }

    }
}
