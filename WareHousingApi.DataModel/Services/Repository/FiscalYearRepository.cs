using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Common;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class FiscalYearRepository :UnitOfWork, IFiscalYearRepository
    {

        public FiscalYearRepository(ApplicationDbContext context) : base(context)
        {
        }

        public FiscalYears_Tbl UpdateFiscalYear(FiscalYearEditModel model)
        {
            var getfiscal = this.fiscalYearUW.Get(f => f.FiscalYearID == model.FiscalYearID).FirstOrDefault();

            if (getfiscal != null)
            {
                getfiscal.StartDate = ConvertDate.ConvertShamsiToMiladi(model.StartDateE);
                getfiscal.EndDate = ConvertDate.ConvertShamsiToMiladi(model.EndDateE);
                getfiscal.FiscalYearDescription = model.FiscalYearDescriptionE;

                this.fiscalYearUW.Update(getfiscal);
                this.Save();

                return getfiscal;
            }

            return null;
        }

        public bool CheckDateForFiscalYear(DateTime StartDate, DateTime EndDate)
        {
            //تاریخ شروع باید حتما کمتر از تاریخ پایان باشد
            if (StartDate >= EndDate)
            {
                return false;
            }
            //تاریخ شروع سال مالی باید از همه تاریخهای قبلی به جز خودش بزرگتر باشد
            DateTime dd = this.fiscalYearUW.Get(g => g.StartDate.Date != StartDate.Date).Max(f => f.EndDate).Date;
            if (StartDate.Date <= dd)
            {
                return false;
            }

            return true;
        }
    }
}