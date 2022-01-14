using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class PlayedRepository : IPlayedRepository
    {
        private GamesPlayedContext context;

        public PlayedRepository(GamesPlayedContext c)
        {
            context = c;
        }

        public IQueryable<GameInfoModel> Games
        {
            get
            {
                // Get all the GameInfo objects in the GamesPlayed DbSet
                return context.GameInfo;
            }
        }

        public GameInfoModel GetGameByID(int id)
        {
            return context.GameInfo.Find(id);
        }

        public void AddGame(GameInfoModel game)
        {
            context.GameInfo.Add(game);
            context.SaveChanges();
        }

        public void EditGame(GameInfoModel game)
        {
            context.GameInfo.Update(game);
            context.SaveChanges();
        }

        public void DeleteGame(GameInfoModel game)
        {
            context.GameInfo.Remove(game);
            context.SaveChanges();
        }
    }
}
