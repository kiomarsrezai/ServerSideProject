using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblProjectScale
    {
        public int Id { get; set; }

        public string ProjectScaleName { get; set; }

        public virtual ICollection<TblProject> TblProjects { get; } = new List<TblProject>();
    }
}