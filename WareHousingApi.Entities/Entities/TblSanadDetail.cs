using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSanadDetail
    {
        public int Id { get; set; }

        public int? SanadId { get; set; }

        public int? CodingId { get; set; }

        public int? SuppliersId { get; set; }

        public string Description { get; set; }

        public long? Bedehkar { get; set; }

        public long? Bestankar { get; set; }

        public virtual TblCoding Coding { get; set; }

        public virtual TblSanad Sanad { get; set; }

        public virtual TblSupplier Suppliers { get; set; }
    }
}