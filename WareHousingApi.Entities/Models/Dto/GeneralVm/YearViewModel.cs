using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.GeneralVm
{
    public class YearViewModel
    {
        public int Id { get; set; }

        [Display(Name = "سال")]
        public string YearName { get; set; }
    }
}
