using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Contract
{
    public class ContractAreaInsertViewModel
    {
        public int ContractId { get; set; }
        public int AreaId { get; set; }
    }
}
