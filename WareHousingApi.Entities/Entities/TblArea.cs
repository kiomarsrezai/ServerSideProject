using System;
using System.Collections.Generic;

namespace WareHousingApi.Entities.Entities
{
    public partial class TblArea
    {
        public int Id { get; set; }

        public string AreaName { get; set; }

        public string AreaNameShort { get; set; }

        public int? StructureId { get; set; }

        public byte? OrganizationKind { get; set; }

        public string AreaNumber { get; set; }

        public byte? ToGetherBudget { get; set; }

        public virtual ICollection<TblBudgetDetailProjectArea> TblBudgetDetailProjectAreas { get; } = new List<TblBudgetDetailProjectArea>();

        public virtual ICollection<TblBudgetPerformanceAcceptDetail> TblBudgetPerformanceAcceptDetails { get; } = new List<TblBudgetPerformanceAcceptDetail>();

        public virtual ICollection<TblBudget> TblBudgets { get; } = new List<TblBudget>();

        public virtual ICollection<TblContractArea> TblContractAreas { get; } = new List<TblContractArea>();

        public virtual ICollection<TblDepartman> TblDepartmen { get; } = new List<TblDepartman>();

        public virtual ICollection<TblDepartmentAcceptor> TblDepartmentAcceptors { get; } = new List<TblDepartmentAcceptor>();

        public virtual ICollection<TblOrganization> TblOrganizations { get; } = new List<TblOrganization>();

        public virtual ICollection<TblPayment> TblPayments { get; } = new List<TblPayment>();

        public virtual ICollection<TblPay> TblPays { get; } = new List<TblPay>();

        public virtual ICollection<TblProgramOperation> TblProgramOperations { get; } = new List<TblProgramOperation>();

        public virtual ICollection<TblRequestSign> TblRequestSigns { get; } = new List<TblRequestSign>();

        public virtual ICollection<TblRequest> TblRequests { get; } = new List<TblRequest>();

    }
}