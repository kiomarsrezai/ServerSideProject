using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Models.Dto;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IWastageRialiRepository
    {
        List<WastageRialiStock> GetWastageRialiStock(int FiscalYearID, int WareHouseID);
    }
}
