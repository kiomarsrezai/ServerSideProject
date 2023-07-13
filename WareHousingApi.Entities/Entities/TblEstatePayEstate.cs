using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstatePayEstate
    {
        public int Id { get; set; }

        public string EstateProjectId { get; set; }

        public string NumberAcc { get; set; }

        public string DateAcc { get; set; }

        public string RenovationCode { get; set; }

        public string UseName { get; set; }

        public string Address { get; set; }

        public string Amount { get; set; }
    }
}