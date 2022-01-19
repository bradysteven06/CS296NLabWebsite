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

        public void AddGame(Played game)
        {
            context.PlayedInfo.Add(game);
            context.SaveChanges();
        }

        public void EditGame(Played game)
        {
            context.PlayedInfo.Update(game);
            context.SaveChanges();
        }

        public void DeleteGame(Played game)
        {
            context.PlayedInfo.Remove(game);
            context.SaveChanges();
        }
    }
}
