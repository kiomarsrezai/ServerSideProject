using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Budget")]
        public int? BudgetId { get; set; }

        [ForeignKey("TblCoding")]
        public int? TblCodingId { get; set; }

        public long? MosavabPublic { get; set; }

        public long? Allocation { get; set; }

        public bool? Show { get; set; }

        public virtual TblBudget Budget { get; set; }

        public virtual ICollection<TblBudgetDetailEdit> TblBudgetDetailEdits { get; } = new List<TblBudgetDetailEdit>();

        public virtual ICollection<TblBudgetDetailProject> TblBudgetDetailProjects { get; } = new List<TblBudgetDetailProject>();

        public virtual TblCoding TblCoding { get; set; }
    }
}
