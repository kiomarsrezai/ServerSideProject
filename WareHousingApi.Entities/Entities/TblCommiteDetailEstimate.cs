using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommiteDetailEstimate
    {
        public int Id { get; set; }

        public int? CommiteDetailId { get; set; }

        public string Description { get; set; }

        public double? Quantity { get; set; }

        public long? Price { get; set; }

        public double? Amount { get; set; }

        public virtual TblCommiteDetail CommiteDetail { get; set; }
    }
}