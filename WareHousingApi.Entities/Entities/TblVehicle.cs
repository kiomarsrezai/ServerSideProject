using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVehicle
    {
        public int Id { get; set; }

        public string Nmber1 { get; set; }

        public string Nmber2 { get; set; }

        public string Nmber3 { get; set; }

        public string Nmber4 { get; set; }

        public string Nmber5 { get; set; }

        public string Nmber6 { get; set; }

        public string Nmber7 { get; set; }

        public string Nmber8 { get; set; }

        public string Pelak { get; set; }

        public string AssestCode { get; set; }

        public string PelakTypeId { get; set; }

        public virtual ICollection<TblVehiclesDetail> TblVehiclesDetails { get; } = new List<TblVehiclesDetail>();
    }
}