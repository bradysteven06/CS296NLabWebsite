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
        void AddGame(Played game); // Add a game
        void EditGame(Played game); // Edit game info
        void DeleteGame(Played game); // Delete game
    }
}
