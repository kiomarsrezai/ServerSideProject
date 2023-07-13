using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class CodingMainModalViewModel
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int levelNumber { get; set; }
    }
}
