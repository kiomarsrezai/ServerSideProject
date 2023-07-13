using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class WareHouseRepository : UnitOfWork,IWareHouseRepository
    {

        public WareHouseRepository(ApplicationDbContext context) : base(context)
        {
        
        }

        public WareHouses_Tbl UpdateWareHouse(WareHouseEditModel model)
        {
            var getwarehouse = this.wareHouseUW.Get(f => f.WareHouseID == model.WareHouseID).FirstOrDefault();

            if (getwarehouse != null)
            {
                getwarehouse.WareHouseName = model.WareHouseNameE;
                getwarehouse.WareHouseAddress =model.WareHouseAddressE;
                getwarehouse.WareHouseTel = model.WareHouseTelE;

                this.wareHouseUW.Update(getwarehouse);
                this.Save();

                return getwarehouse;
            }

            return null;
        }
    }
}