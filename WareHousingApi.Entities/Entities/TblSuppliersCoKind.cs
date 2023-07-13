using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSuppliersCoKind
    {
        public int Id { get; set; }

        public string CompanyKindName { get; set; }

        public virtual ICollection<TblSupplier> TblSuppliers { get; } = new List<TblSupplier>();
    }
}