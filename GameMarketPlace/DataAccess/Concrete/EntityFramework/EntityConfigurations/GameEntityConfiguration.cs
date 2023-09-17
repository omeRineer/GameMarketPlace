using Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EntityConfigurations
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(m => m.SystemRequirements)
                .WithOne(o => o.Game)
                .HasForeignKey(fk => fk.GameId);
        }
    }
}
