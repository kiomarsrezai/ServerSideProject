using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblVasetTamin
    {
        public string BodgetId { get; set; }

        public string BodgetDesc { get; set; }

        public string RequestDate { get; set; }

        public long? RequestPrice { get; set; }

        public string ReqDesc { get; set; }

        public string RequestRefStr { get; set; }

        public int? TypeCredit { get; set; }

        public int? SectionExecutive { get; set; }
    }
}