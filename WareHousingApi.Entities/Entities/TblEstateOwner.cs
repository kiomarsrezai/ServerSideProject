using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblEstateOwner
    {
        public int Id { get; set; }

        public string ProjectEstateId { get; set; }

        public string CodeMelli { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Father { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }
    }
}