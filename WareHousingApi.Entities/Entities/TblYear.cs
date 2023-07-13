using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblYear
    {
        public int Id { get; set; }

        public int YearName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateEnd { get; set; }

        public virtual ICollection<TblBudgetPerformanceAccept> TblBudgetPerformanceAccepts { get; } = new List<TblBudgetPerformanceAccept>();

        public virtual ICollection<TblBudget> TblBudgets { get; } = new List<TblBudget>();

        public virtual ICollection<TblCommite> TblCommites { get; } = new List<TblCommite>();

        public virtual ICollection<TblPayment> TblPayments { get; } = new List<TblPayment>();

        public virtual ICollection<TblPay> TblPays { get; } = new List<TblPay>();

        public virtual ICollection<TblRequest> TblRequests { get; } = new List<TblRequest>();

    }
}