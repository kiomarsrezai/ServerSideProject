using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblRequestAcceptor
    {
        public int Id { get; set; }

        public int? RequestId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Responsibility { get; set; }

        public DateTime? DateSend { get; set; }

        public DateTime? DateAccept { get; set; }

        public bool? Accept { get; set; }

        public string Description { get; set; }

        public virtual TblRequest Request { get; set; }
    }
}
