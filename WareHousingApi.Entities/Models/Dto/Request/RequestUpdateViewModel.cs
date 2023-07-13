using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Request
{
    public class RequestUpdateViewModel
    {
        public int Id { get; set; }
        public int? RequestKindId { get; set; }
        public int DoingMethodId { get; set; }
        public string Description { get; set; }
        public long EstimateAmount { get; set; }
        public int? SuppliersId { get; set; }
        public string ResonDoingMethod { get; set; }
    }
}
