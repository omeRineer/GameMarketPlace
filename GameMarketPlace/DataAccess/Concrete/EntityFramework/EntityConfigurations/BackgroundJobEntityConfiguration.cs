using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityConfigurations
{
    public class BackgroundJobEntityConfiguration : IEntityTypeConfiguration<BackgroundJob>
    {
        public void Configure(EntityTypeBuilder<BackgroundJob> builder)
        {
            builder.ToTable("BackgroundJobs");
        }
    }
}
