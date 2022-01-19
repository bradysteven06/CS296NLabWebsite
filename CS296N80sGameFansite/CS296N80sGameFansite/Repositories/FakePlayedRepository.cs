using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public class FakePlayedRepository : IPlayedRepository
    {
        List<Played> games = new List<Played>();

        public IQueryable<Played> Games
        {
            get { return games.AsQueryable<Played>(); }
        }

        public void AddGame(Played game)
        {
            game.GameID = games.Count;
            games.Add(game);
        }

        public void DeleteGame(Played game)
        {
            games.RemoveAt(game.GameID);
        }

        public void EditGame(Played game)
        {
            games[game.GameID].Name = game.Name;
            games[game.GameID].Year = game.Year;
            games[game.GameID].Platform = game.Platform;
        }

        public Played GetGameByID(int id)
        {
            return games[id];
        }
    }
}
