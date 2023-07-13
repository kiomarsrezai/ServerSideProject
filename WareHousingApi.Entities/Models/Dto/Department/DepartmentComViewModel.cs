using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Department
{
    public class DepartmentComViewModel
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }

    }
}
