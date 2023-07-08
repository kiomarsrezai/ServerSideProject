using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.Entities.Entities
{
    public class TblAreas
    {
        [Key]
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string AreaNameShort { get; set; }
        public int StructureId { get; set; }
        public int OrganizationKind { get; set; }
        public string AreaNumber { get; set; }
    }
}
