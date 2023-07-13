using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class CodingManualUpdate
    {
        public int YearId { get; set; }
        public int AreaId { get; set; }
        public int BudgetProcessId { get; set; }
        public int CodingId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
