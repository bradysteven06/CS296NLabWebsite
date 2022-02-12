using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class PlayedRepository : IPlayedRepository
    {
        private GameListContext context;

        public PlayedRepository(GameListContext c)
        {
            context = c;
        }

        public IQueryable<Played> Games
        {
            get
            {
                // Get all the GameInfo objects in the GamesPlayed DbSet
                return context.PlayedInfo;
            }
        }

        public Played GetGameByID(int id)
        {
            return context.PlayedInfo.Find(id);
        }

        public async Task<int> AddGameAsync(Played game)
        {
            await context.PlayedInfo.AddAsync(game);
            return await context.SaveChangesAsync();
        }

        public async Task<int> EditGameAsync(Played game)
        {
            context.PlayedInfo.Update(game);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteGameAsync(Played game)
        {
            context.PlayedInfo.Remove(game);
            return await context.SaveChangesAsync();
        }
    }
}
