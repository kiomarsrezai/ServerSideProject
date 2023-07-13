using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateRegistry
    {
        public int Id { get; set; }

        public int? ProjectEstateId { get; set; }

        public string NumberRegistry { get; set; }

        public DateTime? Date { get; set; }

        public string RegistryName { get; set; }

        public byte? KindId { get; set; }
    }
}