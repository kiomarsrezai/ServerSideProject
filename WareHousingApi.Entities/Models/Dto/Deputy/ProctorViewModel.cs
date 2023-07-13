using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WareHousingApi.Entities.Models.Dto.Deputy
{
    public class ProctorViewModel
    {
        public int Id { get; set; }
        
        [Display(Name ="معاونت")]
        public string ProctorName { get; set; }
    }
}
