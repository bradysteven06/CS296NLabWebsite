using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class WantToPlayRepository : IWantToPlayRepository
    {
        private GameListContext context;

        public WantToPlayRepository(GameListContext c)
        {
            context = c;
        }

        public IQueryable<WantToPlay> Games
        {
            get
            {
                // Get all the GameInfo objects in the GamesPlayed DbSet
                return context.WantToPlayInfo;
            }
        }

        public WantToPlay GetGameByID(int id)
        {
            return context.WantToPlayInfo.Find(id);
        }

        public async Task<int> AddGameAsync(WantToPlay game)
        {
            await context.WantToPlayInfo.AddAsync(game);
            return await context.SaveChangesAsync();
        }

        public async Task<int> EditGameAsync(WantToPlay game)
        {
            context.WantToPlayInfo.Update(game);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteGameAsync(WantToPlay game)
        {
            context.WantToPlayInfo.Remove(game);
            return await context.SaveChangesAsync();
        }
    }
}
