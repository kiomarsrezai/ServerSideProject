using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetDetailProjectAreaDepartment
    {
        public int Id { get; set; }

        [ForeignKey("BudgetDetailProjectArea")]
        public int? BudgetDetailProjectAreaId { get; set; }

        public int? DepartmenId { get; set; }

        public long? MosavabDepartment { get; set; }

        public virtual TblBudgetDetailProjectArea BudgetDetailProjectArea { get; set; }
    }

}