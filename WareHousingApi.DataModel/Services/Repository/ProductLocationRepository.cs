using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;
using WareHousingApi.Entities;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class ProductLocationRepository : UnitOfWork, IProductLocationRepository
    {

        public ProductLocationRepository(ApplicationDbContext context) : base(context)
        {
        }


        public ProductLocations_Tbl UpdateProductLocation(ProductLocationEditModel model)
        {
            var getplocation = this.productLocationUW.Get(f => f.ProductLocationID == model.ProductLocationID).FirstOrDefault();

            if (getplocation != null)
            {
                getplocation.ProductLocationAddress = model.ProductLocationAddressE;

                this.productLocationUW.Update(getplocation);
                this.Save();
                return getplocation;
            }

            return null;
        }
    }
}
