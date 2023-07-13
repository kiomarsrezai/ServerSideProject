using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstatePayBank
    {
        public int Id { get; set; }

        public string ProjectEstateId { get; set; }

        public string NumberAcc { get; set; }

        public string DateAcc { get; set; }

        public string NumberCheck { get; set; }

        public string DateCheck { get; set; }

        public string Amount { get; set; }

        public string Description { get; set; }
    }
}