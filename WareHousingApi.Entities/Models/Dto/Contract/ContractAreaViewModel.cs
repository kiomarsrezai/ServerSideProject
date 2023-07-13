using System;
using System.Collections.Generic;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Contract
{
    public class ContractAreaViewModel
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Int64 ShareAmount { get; set; }
        public string AreaName { get; set; }
    }
}
