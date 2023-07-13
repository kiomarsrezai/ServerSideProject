using System;
using System.Collections.Generic;
namespace WareHousingApi.Entities.Entities
{
    public partial class TblRequest
    {
        public int Id { get; set; }

        public int? YearId { get; set; }

        public int? AreaId { get; set; }

        public string BodgetId { get; set; }

        public string BodgetDesc { get; set; }

        public int? DepartmentId { get; set; }

        public byte? RequestKindId { get; set; }

        public int? SuppliersId { get; set; }

        public int? DoingMethodId { get; set; }

        public string Employee { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public long? EstimateAmount { get; set; }

        public string ResonDoingMethod { get; set; }

        public int? UserId { get; set; }

        public string DateS { get; set; }

        public int? Sal { get; set; }

        public virtual TblArea Area { get; set; }

        public virtual TblDoingMethod DoingMethod { get; set; }

        public virtual TblSupplier Suppliers { get; set; }

        public virtual ICollection<TblContractRequest> TblContractRequests { get; } = new List<TblContractRequest>();

        public virtual ICollection<TblRequestAcceptor> TblRequestAcceptors { get; } = new List<TblRequestAcceptor>();

        public virtual ICollection<TblRequestBudget> TblRequestBudgets { get; } = new List<TblRequestBudget>();


        public virtual ICollection<TblRequestTable> TblRequestTables { get; } = new List<TblRequestTable>();

        public virtual TblYear Year { get; set; }
    }
}
