using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IWareHouseRepository
    {
        WareHouses_Tbl UpdateWareHouse(WareHouseEditModel model);
    }
}
