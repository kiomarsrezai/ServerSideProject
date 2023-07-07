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

namespace WareHousingApi.DataModel
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

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