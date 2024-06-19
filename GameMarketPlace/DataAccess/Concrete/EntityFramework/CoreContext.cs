using Core.Entities.Abstract;
using Core.Entities.Concrete.GeneralSettings;
using Core.Extensions;
using DataAccess.Concrete.EntityFramework.EntityConfigurations;
using Entities.Main;
using MeArch.Module.Security.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.GeneralSettings();
            modelBuilder.ProcessGroups();
            modelBuilder.UserIdentity();
            modelBuilder.MenuItems();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreContext).Assembly);
        }

        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessEntries<Guid>();
            ProcessEntries<int>();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessEntries<TKey>()
        {
            var dataEntries = ChangeTracker.Entries<BaseEntity<Guid>>();
            foreach (var data in dataEntries)
            {
                switch (data.State)
                {
                    case EntityState.Detached: break;
                    case EntityState.Unchanged: break;
                    case EntityState.Deleted: break;
                    case EntityState.Modified: 
                        data.Entity.EditDate = DateTime.Now; 
                        break;
                    case EntityState.Added: 
                        data.Entity.CreateDate = DateTime.Now;
                        data.Entity.EditDate = DateTime.Now; 
                        break;
                }
            }
        }
    }
}
