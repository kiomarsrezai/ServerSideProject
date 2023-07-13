using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetailProject
    {
        public int Id { get; set; }

        [ForeignKey("BudgetDetail")]
        public int? BudgetDetailId { get; set; }

        [ForeignKey("ProgramOperationDetails")]
        public int? ProgramOperationDetailsId { get; set; }

        public long? Mosavab { get; set; }

        public long? EditProject { get; set; }

        public long? Supply { get; set; }

        public long? Takhsis { get; set; }

        public long? Expense { get; set; }

        public virtual TblBudgetDetail BudgetDetail { get; set; }

        public virtual TblProgramOperationDetail ProgramOperationDetails { get; set; }

        public virtual ICollection<TblBudgetDetailProjectArea> TblBudgetDetailProjectAreas { get; } = new List<TblBudgetDetailProjectArea>();
    }
}
