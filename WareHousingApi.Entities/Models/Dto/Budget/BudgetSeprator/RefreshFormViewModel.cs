using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetSeprator
{
    public class RefreshFormViewModel
    {
        [Display(Name = "شناسه")]
        public int areaId { get; set; }
        public int yearId { get; set; }

    }
}
