using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetProject
{
    public class BudgetModal2ProjectSearchParamViewModal
    {
        public int yearId { get; set; }
        public int areaId { get; set; }

    }

}
