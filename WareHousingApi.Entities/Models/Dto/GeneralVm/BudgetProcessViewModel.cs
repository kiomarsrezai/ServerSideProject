using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Models.Dto.GeneralVm
{
    public class BudgetProcessViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نوع بودجه")]
        public string ProcessName { get; set; }
    }
}
