using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.Common.PublicTools;
using WareHousingApi.Entities;
using WareHousingApi.Entities.Base;
using WareHousingApi.Entities.Entities;

namespace WareHousingApi.DataModel
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public virtual DbSet<TblFileDetail> FileDetails { get; set; }

        public virtual DbSet<TblArea> TblAreas { get; set; }

        public virtual DbSet<TblAudit> TblAudits { get; set; }

        public virtual DbSet<TblBudget> TblBudgets { get; set; }

        public virtual DbSet<TblBudgetDetail> TblBudgetDetails { get; set; }

        public virtual DbSet<TblBudgetDetailEdit> TblBudgetDetailEdits { get; set; }

        public virtual DbSet<TblBudgetDetailProject> TblBudgetDetailProjects { get; set; }

        public virtual DbSet<TblBudgetDetailProjectArea> TblBudgetDetailProjectAreas { get; set; }

        public virtual DbSet<TblBudgetDetailProjectAreaDepartment> TblBudgetDetailProjectAreaDepartments { get; set; }

        public virtual DbSet<TblBudgetDetailProjectAreaEdit12345678910> TblBudgetDetailProjectAreaEdit12345678910s { get; set; }

        public virtual DbSet<TblBudgetPerformanceAccept> TblBudgetPerformanceAccepts { get; set; }

        public virtual DbSet<TblBudgetPerformanceAcceptDetail> TblBudgetPerformanceAcceptDetails { get; set; }

        public virtual DbSet<TblBudgetProcess> TblBudgetProcesses { get; set; }

        public virtual DbSet<TblCoding> TblCodings { get; set; }

        public virtual DbSet<TblCodingKind> TblCodingKinds { get; set; }

        public virtual DbSet<TblCodingNature> TblCodingNatures { get; set; }

        public virtual DbSet<TblCodingPbb> TblCodingPbbs { get; set; }

        public virtual DbSet<TblCodingSemak> TblCodingSemaks { get; set; }

        public virtual DbSet<TblCodingSubject> TblCodingSubjects { get; set; }

        public virtual DbSet<TblCodingsMapSazman> TblCodingsMapSazmen { get; set; }

        public virtual DbSet<TblCommite> TblCommites { get; set; }

        public virtual DbSet<TblCommiteDetail> TblCommiteDetails { get; set; }

        public virtual DbSet<TblCommiteDetailAccept> TblCommiteDetailAccepts { get; set; }

        public virtual DbSet<TblCommiteDetailEstimate> TblCommiteDetailEstimates { get; set; }

        public virtual DbSet<TblCommiteDetailWb> TblCommiteDetailWbs { get; set; }

        public virtual DbSet<TblCommiteKind> TblCommiteKinds { get; set; }

        public virtual DbSet<TblContract> TblContracts { get; set; }

        public virtual DbSet<TblContractArea> TblContractAreas { get; set; }

        public virtual DbSet<TblContractRequest> TblContractRequests { get; set; }

        public virtual DbSet<TblCpdate> TblCpdates { get; set; }

        public virtual DbSet<TblCreaditor> TblCreaditors { get; set; }

        public virtual DbSet<TblDepartman> TblDepartmen { get; set; }

        public virtual DbSet<TblDepartmentAcceptor> TblDepartmentAcceptors { get; set; }

        public virtual DbSet<TblDepartmentAcceptorUser> TblDepartmentAcceptorUsers { get; set; }

        public virtual DbSet<TblDoingMethod> TblDoingMethods { get; set; }

        public virtual DbSet<TblEditBudget> TblEditBudgets { get; set; }

        public virtual DbSet<TblEditBudgetKind> TblEditBudgetKinds { get; set; }

        public virtual DbSet<TblEditStatus> TblEditStatuses { get; set; }

        public virtual DbSet<TblEstate> TblEstates { get; set; }

        public virtual DbSet<TblEstateCall> TblEstateCalls { get; set; }

        public virtual DbSet<TblEstateDestruction> TblEstateDestructions { get; set; }

        public virtual DbSet<TblEstateOwner> TblEstateOwners { get; set; }

        public virtual DbSet<TblEstatePayBank> TblEstatePayBanks { get; set; }

        public virtual DbSet<TblEstatePayEstate> TblEstatePayEstates { get; set; }

        public virtual DbSet<TblEstatePayPatent> TblEstatePayPatents { get; set; }

        public virtual DbSet<TblEstateProject> TblEstateProjects { get; set; }

        public virtual DbSet<TblEstateProjectAgreement> TblEstateProjectAgreements { get; set; }

        public virtual DbSet<TblEstateProjectEstimate> TblEstateProjectEstimates { get; set; }

        public virtual DbSet<TblEstateProjectEstimateDetail> TblEstateProjectEstimateDetails { get; set; }

        public virtual DbSet<TblEstateRegistry> TblEstateRegistries { get; set; }

        public virtual DbSet<TblEstateUse> TblEstateUses { get; set; }

        public virtual DbSet<TblGroup> TblGroups { get; set; }

        public virtual DbSet<TblIncome> TblIncomes { get; set; }

        public virtual DbSet<TblIncomeDetail> TblIncomeDetails { get; set; }

        public virtual DbSet<TblInsuranceCompany> TblInsuranceCompanies { get; set; }

        public virtual DbSet<TblKind> TblKinds { get; set; }

        public virtual DbSet<TblKol> TblKols { get; set; }

        public virtual DbSet<TblMoien> TblMoiens { get; set; }

        public virtual DbSet<TblOrganization> TblOrganizations { get; set; }

        public virtual DbSet<TblPay> TblPays { get; set; }

        public virtual DbSet<TblPayment> TblPayments { get; set; }

        public virtual DbSet<TblPaymentAcceptor> TblPaymentAcceptors { get; set; }

        public virtual DbSet<TblPaymentDetail> TblPaymentDetails { get; set; }

        public virtual DbSet<TblPermission> TblPermissions { get; set; }

        public virtual DbSet<TblProctor> TblProctors { get; set; }

        public virtual DbSet<TblProgram> TblPrograms { get; set; }

        public virtual DbSet<TblProgramOperation> TblProgramOperations { get; set; }

        public virtual DbSet<TblProgramOperationDetail> TblProgramOperationDetails { get; set; }

        public virtual DbSet<TblProject> TblProjects { get; set; }

        public virtual DbSet<TblProjectScale> TblProjectScales { get; set; }

        public virtual DbSet<TblRangBudget> TblRangBudgets { get; set; }

        public virtual DbSet<TblRecognition> TblRecognitions { get; set; }

        public virtual DbSet<TblRequest> TblRequests { get; set; }

        public virtual DbSet<TblRequestAcceptor> TblRequestAcceptors { get; set; }

        public virtual DbSet<TblRequestBudget> TblRequestBudgets { get; set; }

        public virtual DbSet<TblRequestSign> TblRequestSigns { get; set; }

        public virtual DbSet<TblRequestTable> TblRequestTables { get; set; }

        public virtual DbSet<TblResponsibility> TblResponsibilities { get; set; }

        public virtual DbSet<TblSalMd> TblSalMds { get; set; }

        public virtual DbSet<TblSanad> TblSanads { get; set; }

        public virtual DbSet<TblSanadDetail> TblSanadDetails { get; set; }

        public virtual DbSet<TblSanadDetailMd> TblSanadDetailMds { get; set; }

        public virtual DbSet<TblSanadKind> TblSanadKinds { get; set; }

        public virtual DbSet<TblSanadMd> TblSanadMds { get; set; }

        public virtual DbSet<TblSanadState> TblSanadStates { get; set; }

        public virtual DbSet<TblSanadStatus> TblSanadStatuses { get; set; }

        public virtual DbSet<TblSign> TblSigns { get; set; }

        public virtual DbSet<TblSignDetail> TblSignDetails { get; set; }

        public virtual DbSet<TblSupplier> TblSuppliers { get; set; }

        public virtual DbSet<TblSuppliersCall> TblSuppliersCalls { get; set; }

        public virtual DbSet<TblSuppliersCoKind> TblSuppliersCoKinds { get; set; }

        public virtual DbSet<TblTafsily> TblTafsilies { get; set; }

        public virtual DbSet<TblVaset> TblVasets { get; set; }

        public virtual DbSet<TblVasetTamin> TblVasetTamins { get; set; }

        public virtual DbSet<TblVasetTarazSazman> TblVasetTarazSazmen { get; set; }

        public virtual DbSet<TblVasetsBank> TblVasetsBanks { get; set; }

        public virtual DbSet<TblVehicle> TblVehicles { get; set; }

        public virtual DbSet<TblVehiclesDetail> TblVehiclesDetails { get; set; }

        public virtual DbSet<TblVehiclesKindInsurance> TblVehiclesKindInsurances { get; set; }

        public virtual DbSet<TblVehiclesTransfer> TblVehiclesTransfers { get; set; }

        public virtual DbSet<TblVehiclestechnicalDiagnosis> TblVehiclestechnicalDiagnoses { get; set; }

        public virtual DbSet<TblYear> TblYears { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var AssemblyProject = typeof(IEntityObject).Assembly;
            builder.VerifyEntities<IEntityObject>(AssemblyProject);


            builder.Entity<ApplicationUsers>(entity =>
            {
                entity.ToTable(name: "Users_Tbl");
                entity.Property(e => e.Id).HasColumnName("UserID");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<ApplicationRoles>(entity =>
            {
                entity.ToTable(name: "Roles_Tbl");
            });

            builder.Entity<TblCpdate>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<TblVaset>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<TblVasetTamin>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<TblVasetTarazSazman>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<TblVasetsBank>(entity =>
            {
                entity.HasNoKey();
            });
        }


        public override int SaveChanges()
        {
            cleanStr();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            cleanStr();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            cleanStr();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            cleanStr();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void cleanStr()
        {
            var changedEntities = ChangeTracker.Entries()
                //پيدا کردن رکوردهایی که عمليات افزودن و ویرایش دارند
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);


            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;
                //فيلدهايي که مقدارشون استرينگ باشه و قابليت خواندن و نوشتن داشته باشند
                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    //اگر پراپرتي مقدار داشت
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
    }
}