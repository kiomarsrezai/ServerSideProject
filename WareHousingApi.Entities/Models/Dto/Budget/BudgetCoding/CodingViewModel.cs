﻿using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetCoding
{
    public class CodingViewModel
    {

        public int Id { get; set; }
        public int? MotherId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int levelNumber { get; set; }
        public bool Crud { get; set; }
        public bool Show { get; set; }
        public int CodingKindId { get; set; }
    }
}
