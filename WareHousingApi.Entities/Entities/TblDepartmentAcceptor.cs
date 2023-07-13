using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblDepartmentAcceptor
    {
        public int Id { get; set; }

        [ForeignKey("Departman")]
        public int? DepartmanId { get; set; }

        [ForeignKey("Area")]
        public int? AreaId { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblDepartman Departman { get; set; }

        public virtual ICollection<TblDepartmentAcceptorUser> TblDepartmentAcceptorUsers { get; } = new List<TblDepartmentAcceptorUser>();
    }
}