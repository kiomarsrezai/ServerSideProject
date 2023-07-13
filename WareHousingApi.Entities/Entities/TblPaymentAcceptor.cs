using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblPaymentAcceptor
    {
        public int Id { get; set; }

        public int? PaymentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateSend { get; set; }

        public DateTime? DateEnd { get; set; }

        public string Description { get; set; }

        public bool? Accept { get; set; }

        public virtual TblPayment Payment { get; set; }
    }
}