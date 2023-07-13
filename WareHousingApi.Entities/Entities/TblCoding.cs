using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCoding
    {
        public int Id { get; set; }

        [ForeignKey("Mother")]
        public int? MotherId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int? LevelNumber { get; set; }

        public int? TblBudgetProcessId { get; set; }

        public bool? Show { get; set; }

        public bool? Crud { get; set; }

        public int? CodingPbbid { get; set; }

        public string CodePbb { get; set; }

        public string CodeVaset { get; set; }

        public int? ProctorId { get; set; }

        public int? CodingKindId { get; set; }

        public string CodeVasetTaminEtebarat { get; set; }

        public int? SubjectId { get; set; }

        public int? CodingNatureId { get; set; }

        public virtual TblCodingKind CodingKind { get; set; }

        public virtual TblCodingNature CodingNature { get; set; }

        public virtual TblCodingPbb CodingPbb { get; set; }

        public virtual ICollection<TblCoding> InverseMother { get; } = new List<TblCoding>();

        public virtual TblCoding Mother { get; set; }

        public virtual TblProctor Proctor { get; set; }

        public virtual TblCodingSubject Subject { get; set; }

        public virtual ICollection<TblBudgetDetail> TblBudgetDetails { get; } = new List<TblBudgetDetail>();

        public virtual TblBudgetProcess TblBudgetProcess { get; set; }

        public virtual ICollection<TblCodingsMapSazman> TblCodingsMapSazmen { get; } = new List<TblCodingsMapSazman>();

        public virtual ICollection<TblSanadDetail> TblSanadDetails { get; } = new List<TblSanadDetail>();
    }
}
