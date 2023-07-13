using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommiteKind
    {
        public int Id { get; set; }

        public string CommiteName { get; set; }

        public virtual ICollection<TblCommite> TblCommites { get; } = new List<TblCommite>();
    }
}