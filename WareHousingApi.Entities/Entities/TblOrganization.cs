using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblOrganization
    {
        public int Id { get; set; }

        public int? MotherId { get; set; }

        public int? AreaId { get; set; }

        public string OrgCode { get; set; }

        public string OrgName { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual ICollection<TblOrganization> InverseMother { get; } = new List<TblOrganization>();

        public virtual TblOrganization Mother { get; set; }
    }
}