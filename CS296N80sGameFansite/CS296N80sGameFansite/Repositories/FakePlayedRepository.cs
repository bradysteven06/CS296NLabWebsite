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

        public async Task<int> AddGameAsync(Played game)
        {
            game.GameID = games.Count;
            await Task<int>.Run(() => games.Add(game));
            return 1;
        }

        public async Task<int> DeleteGameAsync(Played game)
        {
            await Task<int>.Run(() => games.RemoveAt(game.GameID));
            return 1;
        }

        public async Task<int> EditGameAsync(Played game)
        {
            await Task<int>.Run(() => games[game.GameID].Name = game.Name);
            await Task<int>.Run(() => games[game.GameID].Year = game.Year);
            await Task<int>.Run(() => games[game.GameID].Platform = game.Platform);
            return 1;
        }

        public Played GetGameByID(int id)
        {
            return games[id];
        }
    }
}
