using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetProject
{
    public class BudgetModal2ProjectInsertParamModel
    {
        public int ProgramOperationDetailsId { get; set; }
        public int YearId { get; set; }
        public int AreaId { get; set; }
        public int BudgetDetailId { get; set; }

    }
}
