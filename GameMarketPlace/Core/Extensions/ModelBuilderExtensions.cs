using Core.Entities.Concrete.GeneralSettings;
using Core.Entities.Concrete.Menu;
using Core.Entities.Concrete.Notification;
using Core.Entities.Concrete.ProcessGroups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ProcessGroups(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessGroup>()
                        .ToTable("ProcessGroups")
                        .Property(p => p.Id).ValueGeneratedNever();

            modelBuilder.Entity<TypeLookup>()
                        .ToTable("TypeLookups")
                        .Property(p => p.Id).ValueGeneratedNever();

            modelBuilder.Entity<StatusLookup>()
                        .ToTable("StatusLookups")
                        .Property(p => p.Id).ValueGeneratedNever();

            return modelBuilder;
        }

        public static ModelBuilder GeneralSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralSetting>()
                        .ToTable("GeneralSettings")
                        .Property(p => p.IsCached).HasDefaultValue(false);


            return modelBuilder;
        }

        public static ModelBuilder MenuItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                        .ToTable("Menus");

            return modelBuilder;
        }

        public static ModelBuilder Notifications(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                        .ToTable("Notifications");

            return modelBuilder;
        }
    }
}
