using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblRequestTable
    {
        public int Id { get; set; }

        public int? RequestId { get; set; }

        public string Description { get; set; }

        public double? Quantity { get; set; }

        public string Scale { get; set; }

        public long? Price { get; set; }

        public double? Amount { get; set; }

        public string OthersDescription { get; set; }

        public virtual TblRequest Request { get; set; }
    }
}
