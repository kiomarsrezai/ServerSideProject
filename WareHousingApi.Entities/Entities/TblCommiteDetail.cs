using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommiteDetail
    {
        public int Id { get; set; }

        public byte? Row { get; set; }

        public int? CommiteId { get; set; }

        public string Description { get; set; }

        public int? ProjectId { get; set; }

        public virtual TblCommite Commite { get; set; }

        public virtual TblProject Project { get; set; }

        public virtual ICollection<TblCommiteDetailAccept> TblCommiteDetailAccepts { get; } = new List<TblCommiteDetailAccept>();

        public virtual ICollection<TblCommiteDetailEstimate> TblCommiteDetailEstimates { get; } = new List<TblCommiteDetailEstimate>();

        public virtual ICollection<TblCommiteDetailWb> TblCommiteDetailWbs { get; } = new List<TblCommiteDetailWb>();
    }
}