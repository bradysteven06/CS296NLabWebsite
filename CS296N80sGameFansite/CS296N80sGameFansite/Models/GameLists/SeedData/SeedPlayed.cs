using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS296N80sGameFansite.Models
{
    internal class SeedPlayed : IEntityTypeConfiguration<Played>
    {
        public void Configure(EntityTypeBuilder<Played> entity)
        {
            entity.HasData(
                new Played { GameID = 1, Name = "Tetris", Year = 1989, Platform = "Nintendo" },
                new Played { GameID = 2, Name = "Donkey Kong", Year = 1981, Platform = "Arcade" }
                );
        }
    }
}
