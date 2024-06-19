using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EntityConfigurations
{
    public class SliderContentEntityConfiguration : IEntityTypeConfiguration<SliderContent>
    {
        public void Configure(EntityTypeBuilder<SliderContent> builder)
        {
            builder.ToTable("SliderContents");

            builder
                .HasKey(x => x.Id);

            builder.Property(p => p.IsActive)
                   .HasDefaultValue(false);
        }
    }
}
