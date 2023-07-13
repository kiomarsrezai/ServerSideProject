﻿using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class BudgetConnect_ReadViewModel
    {

        public int Id { get; set; }
        public int? ProctorId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int BudgetDetailId { get; set; }
        public string ProctorName { get; set; }
        public bool? Show { get; set; }
        public long Mosavab { get; set; }
        public int? CodingNatureId { get; set; }
        public string CodingNatureName { get; set; }

    }
}
