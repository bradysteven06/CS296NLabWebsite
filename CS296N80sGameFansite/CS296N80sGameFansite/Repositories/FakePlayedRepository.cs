using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class FakePlayedRepository : IPlayedRepository
    {
        List<GameInfoModel> games = new List<GameInfoModel>();

        public IQueryable<GameInfoModel> Games
        {
            get { return games.AsQueryable<GameInfoModel>(); }
        }

        public void AddGame(GameInfoModel game)
        {
            game.GameID = games.Count;
            games.Add(game);
        }

        public void DeleteGame(GameInfoModel game)
        {
            games.RemoveAt(game.GameID);
        }

        public void EditGame(GameInfoModel game)
        {
            games[game.GameID].Name = game.Name;
            games[game.GameID].Year = game.Year;
            games[game.GameID].Platform = game.Platform;
        }

        public GameInfoModel GetGameByID(int id)
        {
            return games[id];
        }
    }
}
