using System;
using System.Collections.Generic;
namespace WareHousingApi.Entities.Entities
{
    public partial class TblProject
    {
        public int Id { get; set; }

        public int? MotherId { get; set; }

        public string ProjectCode { get; set; }

        public string ProjectName { get; set; }

        public int? AreaId { get; set; }

        public double? Weight { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateEnd { get; set; }

        public string AreaList { get; set; }

        public int? ProjectScaleId { get; set; }

        public string AreaArray { get; set; }

        public virtual ICollection<TblFileDetail> FileDetails { get; } = new List<TblFileDetail>();

        public virtual ICollection<TblProject> InverseMother { get; } = new List<TblProject>();

        public virtual TblProject Mother { get; set; }

        public virtual TblProjectScale ProjectScale { get; set; }

        public virtual ICollection<TblCommiteDetail> TblCommiteDetails { get; } = new List<TblCommiteDetail>();

        public virtual ICollection<TblProgramOperationDetail> TblProgramOperationDetails { get; } = new List<TblProgramOperationDetail>();
    }
}
