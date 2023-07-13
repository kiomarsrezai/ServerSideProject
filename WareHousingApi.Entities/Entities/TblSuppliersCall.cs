using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSuppliersCall
    {
        public int Id { get; set; }

        public int? SuppliersId { get; set; }

        public string Description { get; set; }

        public string Number { get; set; }

        public virtual TblSupplier Suppliers { get; set; }
    }
}