using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblDoingMethod
    {
        public int Id { get; set; }

        public string MethodName { get; set; }

        public virtual ICollection<TblRequest> TblRequests { get; } = new List<TblRequest>();
    }
}