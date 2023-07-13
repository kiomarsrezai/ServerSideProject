using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudget
    {
        public int Id { get; set; }

        [ForeignKey("TblYear")]
        public int? TblYearId { get; set; }

        [ForeignKey("TblArea")]
        public int? TblAreaId { get; set; }

        public string ActiveRevenue { get; set; }

        public string ActiveCivil { get; set; }

        public string ActiveCurrent { get; set; }

        public string ActiveFinancial { get; set; }

        public byte? OrganizationKind { get; set; }

        public virtual TblArea TblArea { get; set; }

        public virtual ICollection<TblBudgetDetail> TblBudgetDetails { get; } = new List<TblBudgetDetail>();

        public virtual TblYear TblYear { get; set; }
    }
}