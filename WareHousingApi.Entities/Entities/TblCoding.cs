using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Entities
{
    public class TblCoding
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey("MotherId")]
        public int ParentId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int levelNumber { get; set; }
        public int ProctorId { get; set; }
        public bool Crud { get; set; }
        public bool Show { get; set; }
        public int CodingRevenueKind { get; set; }

        public virtual TblBudgetProcess BudgetProcessId { get; set; }
        public virtual TblCoding MotherId { get; set; }
        public virtual List<TblCoding> TblCodings { get; set; }
    }
}
