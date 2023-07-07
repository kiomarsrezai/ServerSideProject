using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IFiscalYearRepository
    {
        FiscalYears_Tbl UpdateFiscalYear(FiscalYearEditModel model);
        bool CheckDateForFiscalYear(DateTime StartDate, DateTime EndDate);
    }
}