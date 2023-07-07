using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IEntityTransaction : IDisposable
    {
        void Commit();
        void RollBack();
        //void Dispose();
    }
}
