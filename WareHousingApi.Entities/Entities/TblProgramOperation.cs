using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblProgramOperation
    {
        public int Id { get; set; }

        [ForeignKey("TblArea")]
        public int? TblAreaId { get; set; }

        [ForeignKey("TblProgram")]
        public int? TblProgramId { get; set; }

        public virtual TblArea TblArea { get; set; }

        public virtual TblProgram TblProgram { get; set; }

        public virtual ICollection<TblProgramOperationDetail> TblProgramOperationDetails { get; } = new List<TblProgramOperationDetail>();
    }
}
