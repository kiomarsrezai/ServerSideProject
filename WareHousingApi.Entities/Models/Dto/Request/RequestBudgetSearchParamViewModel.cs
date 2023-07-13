using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Request
{
    public class RequestBudgetSearchParamViewModel

    {
        public int YearId { get; set; }
        public int AreaId { get; set; }
        public int DepartmentId { get; set; }
    }
}
