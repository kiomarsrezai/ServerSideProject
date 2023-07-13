using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblContract
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string DateS { get; set; }

        public string Description { get; set; }

        public int? SuppliersId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateEnd { get; set; }

        public byte? DoingMethodId { get; set; }

        public long? Amount { get; set; }

        public long? Surplus { get; set; }

        public bool? Final { get; set; }

        public string ZemanatNumber { get; set; }

        public decimal? ZemanatPrice { get; set; }

        public string ZemanatDate { get; set; }

        public int? ZemanatBank { get; set; }

        public string ZemanatShobe { get; set; }

        public string ZemanatModat { get; set; }

        public string ZemanatModatUnit { get; set; }

        public string ZemanatEndDate { get; set; }

        public int? ZemanatType { get; set; }

        public string Type { get; set; }

        public string Agreement46 { get; set; }

        public string Agreement48 { get; set; }

        public virtual TblSupplier Suppliers { get; set; }

        public virtual ICollection<TblContractArea> TblContractAreas { get; } = new List<TblContractArea>();

        public virtual ICollection<TblContractRequest> TblContractRequests { get; } = new List<TblContractRequest>();
    }
}