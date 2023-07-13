using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetPerformanceAcceptDetail
    {
        public int Id { get; set; }

        public int? BudgetPerformanceAcceptId { get; set; }

        public int? AreaId { get; set; }

        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Responsibility { get; set; }

        public DateTime? Date { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblBudgetPerformanceAccept BudgetPerformanceAccept { get; set; }
    }
}