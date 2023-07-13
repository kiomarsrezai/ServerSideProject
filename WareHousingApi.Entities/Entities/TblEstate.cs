using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstate
    {
        public int Id { get; set; }

        public string AreaId { get; set; }

        public string NeighborhoodId { get; set; }

        public string Block { get; set; }

        public string RenovationCode { get; set; }
    }
}