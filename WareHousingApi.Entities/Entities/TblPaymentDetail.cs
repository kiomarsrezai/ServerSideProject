using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblPaymentDetail
    {
        public int Id { get; set; }

        public int? PaymentId { get; set; }

        public int? RequestContractId { get; set; }

        public virtual TblPayment Payment { get; set; }
    }
}