using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateProjectAgreement
    {
        public int Id { get; set; }

        public string NumberAgreement { get; set; }

        public string DateAgreement { get; set; }

        public string AmountCash { get; set; }

        public string AmountEstate { get; set; }

        public string AmountPatent { get; set; }
    }
}