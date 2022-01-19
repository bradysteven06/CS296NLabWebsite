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

        public void AddGame(WantToPlay game)
        {
            context.WantToPlayInfo.Add(game);
            context.SaveChanges();
        }

        public void EditGame(WantToPlay game)
        {
            context.WantToPlayInfo.Update(game);
            context.SaveChanges();
        }

        public void DeleteGame(WantToPlay game)
        {
            context.WantToPlayInfo.Remove(game);
            context.SaveChanges();
        }
    }
}
