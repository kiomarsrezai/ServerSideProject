using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblContractRequest
    {
        public int Id { get; set; }

        public int? ContractId { get; set; }

        public int? RequestId { get; set; }

        public virtual TblContract Contract { get; set; }

        public virtual TblRequest Request { get; set; }
    }
}