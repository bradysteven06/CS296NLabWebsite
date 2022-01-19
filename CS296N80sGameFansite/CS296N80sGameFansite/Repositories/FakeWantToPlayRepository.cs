using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class FakeWantToPlayRepository : IWantToPlayRepository
    {
        List<WantToPlay> games = new List<WantToPlay>();

        public IQueryable<WantToPlay> Games
        {
            get { return games.AsQueryable<WantToPlay>(); }
        }

        public void AddGame(WantToPlay game)
        {
            game.GameID = games.Count;
            games.Add(game);
        }

        public void DeleteGame(WantToPlay game)
        {
            games.RemoveAt(game.GameID);
        }

        public void EditGame(WantToPlay game)
        {
            games[game.GameID].Name = game.Name;
            games[game.GameID].Year = game.Year;
            games[game.GameID].Platform = game.Platform;
        }

        public WantToPlay GetGameByID(int id)
        {
            return games[id];
        }
    }
}
