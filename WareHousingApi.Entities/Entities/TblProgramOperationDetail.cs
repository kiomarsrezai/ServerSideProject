using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblProgramOperationDetail
    {
        public int Id { get; set; }

        [ForeignKey("TblProgramOperation")]
        public int? TblProgramOperationId { get; set; }

        [ForeignKey("TblProject")]
        public int? TblProjectId { get; set; }

        public virtual ICollection<TblBudgetDetailProject> TblBudgetDetailProjects { get; } = new List<TblBudgetDetailProject>();

        public virtual TblProgramOperation TblProgramOperation { get; set; }

        public virtual TblProject TblProject { get; set; }
    }
}
