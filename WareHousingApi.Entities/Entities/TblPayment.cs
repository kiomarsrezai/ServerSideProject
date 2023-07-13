using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblPayment
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public int? PaymentKindId { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public long? Amount { get; set; }

        public int? YearId1 { get; set; }

        public int? AreaId1 { get; set; }

        public string Number1 { get; set; }

        public DateTime? Date1 { get; set; }

        public string Description1 { get; set; }

        public int? SuppliersId { get; set; }

        public string SuppliersName { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string BankNumber { get; set; }

        public long? PureAmount { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual ICollection<TblPaymentAcceptor> TblPaymentAcceptors { get; } = new List<TblPaymentAcceptor>();

        public virtual ICollection<TblPaymentDetail> TblPaymentDetails { get; } = new List<TblPaymentDetail>();

        public virtual TblYear Year { get; set; }
    }
}