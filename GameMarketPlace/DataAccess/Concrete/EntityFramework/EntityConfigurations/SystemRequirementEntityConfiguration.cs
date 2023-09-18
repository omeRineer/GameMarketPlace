using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EntityConfigurations
{
    public class SystemRequirementEntityConfiguration : IEntityTypeConfiguration<SystemRequirement>
    {
        public void Configure(EntityTypeBuilder<SystemRequirement> builder)
        {
            builder.ToTable("SystemRequirements");

            builder
                .HasKey(x => x.Id);
        }
    }
}
