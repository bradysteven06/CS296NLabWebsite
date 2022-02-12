using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public interface IWantToPlayRepository
    {
        IQueryable<WantToPlay> Games { get; } // Read games
        WantToPlay GetGameByID(int id); // Returns a game
        Task<int> AddGameAsync(WantToPlay game); // Add a game
        Task<int> EditGameAsync(WantToPlay game); // Edit game info
        Task<int> DeleteGameAsync(WantToPlay game); // Delete game
    }
}
