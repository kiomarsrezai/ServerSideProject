﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WareHousingApi.Entities.Models.Dto.Budget.BudgetArea
{
    public class BudgetAreaModalViewModel
    {
        public int Id { get; set; }

        public string AreaName { get; set; }

        public long Mosavab { get; set; }

        public long EditArea { get; set; }

        public long Expense { get; set; }

        public double PercentBud { get; set; }
        public long Supply { get; set; }
    }



}
