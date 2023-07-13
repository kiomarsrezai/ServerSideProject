using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblCommiteDetailWb
    {
        public int Id { get; set; }

        public int? CommiteDetailId { get; set; }

        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Responsibility { get; set; }

        public string Description { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public virtual TblCommiteDetail CommiteDetail { get; set; }
    }
}