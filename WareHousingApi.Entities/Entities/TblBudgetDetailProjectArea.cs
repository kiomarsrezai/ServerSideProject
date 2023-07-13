using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetailProjectArea
    {
        public int Id { get; set; }

        [ForeignKey("BudgetDetailProject")]
        public int? BudgetDetailProjectId { get; set; }

        [ForeignKey("Area")]
        public int? AreaId { get; set; }

        public long? Mosavab { get; set; }

        public long? EditArea { get; set; }

        public long? Supply { get; set; }

        public long? Takhsis { get; set; }

        public long? Expense { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblBudgetDetailProject BudgetDetailProject { get; set; }

        public virtual ICollection<TblBudgetDetailProjectAreaDepartment> TblBudgetDetailProjectAreaDepartments { get; } = new List<TblBudgetDetailProjectAreaDepartment>();

        public virtual ICollection<TblBudgetDetailProjectAreaEdit12345678910> TblBudgetDetailProjectAreaEdit12345678910s { get; } = new List<TblBudgetDetailProjectAreaEdit12345678910>();

        public virtual ICollection<TblRequestBudget> TblRequestBudgets { get; } = new List<TblRequestBudget>();
    }
}
