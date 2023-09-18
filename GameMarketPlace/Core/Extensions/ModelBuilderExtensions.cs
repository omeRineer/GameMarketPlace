using Core.Entities.Concrete.GeneralSettings;
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
                        .ToTable("ProcessGroups");

            modelBuilder.Entity<TypeLookup>()
                        .ToTable("TypeLookups");

            modelBuilder.Entity<StatusLookup>()
                        .ToTable("StatusLookups");

            return modelBuilder;
        }

        public static ModelBuilder GeneralSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralSetting>()
                        .ToTable("GeneralSettings");

            return modelBuilder;
        }
    }
}
