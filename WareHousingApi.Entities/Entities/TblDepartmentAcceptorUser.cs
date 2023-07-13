using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblDepartmentAcceptorUser
    {
        public int Id { get; set; }

        public int? DepartmanAcceptorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Resposibility { get; set; }

        public int? UserId { get; set; }

        public virtual TblDepartmentAcceptor DepartmanAcceptor { get; set; }
    }
}