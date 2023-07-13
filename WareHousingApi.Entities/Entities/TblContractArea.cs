using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblContractArea
    {
        public int Id { get; set; }

        public int? ContractId { get; set; }

        public int? AreaId { get; set; }

        public long? ShareAmount { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblContract Contract { get; set; }
    }
}