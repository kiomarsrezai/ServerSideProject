using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblDepartman
    {
        public int Id { get; set; }

        [ForeignKey("Mother")]
        public int? MotherId { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public int? AreaId { get; set; }

        public bool? Active { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual ICollection<TblDepartman> InverseMother { get; } = new List<TblDepartman>();

        public virtual TblDepartman Mother { get; set; }

        public virtual ICollection<TblDepartmentAcceptor> TblDepartmentAcceptors { get; } = new List<TblDepartmentAcceptor>();

        public virtual ICollection<TblRequestSign> TblRequestSigns { get; } = new List<TblRequestSign>();
    }
}