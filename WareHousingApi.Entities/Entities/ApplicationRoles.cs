using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities
{
    public class ApplicationRoles : IdentityRole<string>, IEntityObject
    {
        public DateTime CreateDateTime { get; set; }
    }
}
