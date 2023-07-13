using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetArea
{

    public class BudgetModal3ParamAreaInsert
    {
        public int areaPublicId { get; set; }
        public int yearId { get; set; }
        public int codingId { get; set; }
        public int projectId { get; set; }
        public int areaId { get; set; }
    }
}
