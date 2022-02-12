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

        public async Task<int> AddGameAsync(WantToPlay game)
        {
            game.GameID = games.Count;
            await Task<int>.Run(() => games.Add(game));
            return 1;
        }

        public async Task<int> DeleteGameAsync(WantToPlay game)
        {
            await Task<int>.Run(() => games.RemoveAt(game.GameID));
            return 1;
        }

        public async Task<int> EditGameAsync(WantToPlay game)
        {
            await Task<int>.Run(() => games[game.GameID].Name = game.Name);
            await Task<int>.Run(() => games[game.GameID].Year = game.Year);
            await Task<int>.Run(() => games[game.GameID].Platform = game.Platform);
            return 1;
        }

        public WantToPlay GetGameByID(int id)
        {
            return games[id];
        }
    }
}
