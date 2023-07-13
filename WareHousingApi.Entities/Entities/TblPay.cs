using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblPay
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public int? SuppliersId { get; set; }

        public string SuppliersName { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string BankNumber { get; set; }

        public long? PureAmount { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblYear Year { get; set; }
    }
}