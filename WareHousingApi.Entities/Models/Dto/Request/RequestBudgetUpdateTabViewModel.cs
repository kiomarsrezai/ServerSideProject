using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Request
{
    public class RequestBudgetUpdateTabViewModel
    {
        public int Id { get; set; }
        public Int64 RequestBudgetAmount { get; set; }
    }
}
