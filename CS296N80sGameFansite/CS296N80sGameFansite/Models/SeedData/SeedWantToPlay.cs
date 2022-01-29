using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    internal class SeedWantToPlay : IEntityTypeConfiguration<WantToPlay>
    {
        public void Configure(EntityTypeBuilder<WantToPlay> entity)
        {
            entity.HasData(
                new WantToPlay { GameID = 1, Name = "Tetris", Year = 1989, Platform = "Nintendo" },
                new WantToPlay { GameID = 2, Name = "Test", Year = 1981, Platform = "Testrix" }
                );
        }
    }
}
