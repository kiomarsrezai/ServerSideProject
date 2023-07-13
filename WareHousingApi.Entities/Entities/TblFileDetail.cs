using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblFileDetail
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        [ForeignKey("TblProject")]
        public int ProjectId { get; set; }

        public virtual TblProject TblProject { get; set; }
    }
}