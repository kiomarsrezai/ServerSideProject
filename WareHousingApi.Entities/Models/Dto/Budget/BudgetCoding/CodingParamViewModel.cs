using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class CodingParamViewModel
    {
        public int? MotherId { get; set; }

        public int BudgetProcessId { get; set; }
    }
}
