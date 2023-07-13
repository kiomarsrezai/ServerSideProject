using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommiteDetailAccept
    {
        public int Id { get; set; }

        public int? CommiteDetailId { get; set; }

        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Resposibility { get; set; }

        public DateTime? DateAccept { get; set; }

        public virtual TblCommiteDetail CommiteDetail { get; set; }
    }
}