using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblSignDetail
    {
        public int Id { get; set; }

        public int? SignId { get; set; }

        public string Sample { get; set; }

        public virtual TblSign Sign { get; set; }
    }
}