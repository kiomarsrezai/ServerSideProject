using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IProductLocationRepository
    {
        ProductLocations_Tbl UpdateProductLocation(ProductLocationEditModel model);
    }
}
