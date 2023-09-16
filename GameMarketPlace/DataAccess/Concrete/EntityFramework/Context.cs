using Core.Entities.Abstract;
using Core.Entities.Concrete.GeneralSettings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<GeneralSetting> GeneralSettings { get; set; }

        public override int SaveChanges()
        {
            var dataEntries = ChangeTracker.Entries<BaseEntity<object>>();
            foreach (var data in dataEntries)
            {
                switch (data.State)
                {
                    case EntityState.Detached: break;
                    case EntityState.Unchanged: break;
                    case EntityState.Deleted: break;
                    case EntityState.Modified: data.Entity.EditDate = DateTime.Now; break;
                    case EntityState.Added: data.Entity.CreateDate = DateTime.Now; break;
                }
            }
            return base.SaveChanges();
        }
    }
}
