using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Models.Dto.Public
{
    public class ReadPublicParamViewModel
    {
        public int yearId { get; set; }
        public int areaId { get; set; }
        public int budgetProcessId { get; set; }
    }
}
