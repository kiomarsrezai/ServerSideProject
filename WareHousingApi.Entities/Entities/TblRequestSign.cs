using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WareHousingApi.Entities;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblRequestSign
    {
        public int Id { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("Area")]

        public int? AreaId { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblDepartman Department { get; set; }

        public virtual ApplicationUsers Employee { get; set; }
    }
}