using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Entities.Base;

namespace WareHousingApi.Entities
{
    public class ApplicationUsers : IdentityUser<string>, IEntityObject
    {
        public string FirstName { get; set; } 
        public string Family { get; set; } 
        public string UserImage { get; set; } 
        public string MelliCode { get; set; }
        public string PersonalCode { get; set; }
        public DateTime BirthDayDate { get; set; }
        public DateTime CreateDateTime { get; set; }
        //true == مرد
        //false == زن
        public bool Gender { get; set; }
        //1 = Admin
        //2 = User
        public byte UserType { get; set; }
    }
}
