using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSupplier
    {
        public int Id { get; set; }

        public string RegisterDate { get; set; }

        public string RegisterNumber { get; set; }

        public string SuppliersName { get; set; }

        public int? SuppliersCoKindId { get; set; }

        public string Shenase { get; set; }

        public string EconomicalNumber { get; set; }

        public string EstablishmentDate { get; set; }

        public string Tel { get; set; }

        public string Mobile { get; set; }

        public int? SuppliersKindId { get; set; }

        public string NationalCode { get; set; }

        public string FirsrtName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string NationalIdco { get; set; }

        public string RegistrationNumberCo { get; set; }

        public bool? BlackList { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string NumberBank { get; set; }

        public virtual TblSuppliersCoKind SuppliersCoKind { get; set; }

        public virtual ICollection<TblContract> TblContracts { get; } = new List<TblContract>();

        public virtual ICollection<TblRequest> TblRequests { get; } = new List<TblRequest>();

        public virtual ICollection<TblSanadDetail> TblSanadDetails { get; } = new List<TblSanadDetail>();

        public virtual ICollection<TblSuppliersCall> TblSuppliersCalls { get; } = new List<TblSuppliersCall>();
    }
}