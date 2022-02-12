using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public interface IPlayedRepository
    {
        IQueryable<Played> Games { get; } // Read games
        Played GetGameByID(int id); // Returns a game
        Task<int> AddGameAsync(Played game); // Add a game
        Task<int> EditGameAsync(Played game); // Edit game info
        Task<int> DeleteGameAsync(Played game); // Delete game
    }
}
