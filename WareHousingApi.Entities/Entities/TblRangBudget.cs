using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblRangBudget
    {
        public int Id { get; set; }

        public long? FromNumber { get; set; }

        public long? EndNumber { get; set; }

        public string Description { get; set; }
    }
}