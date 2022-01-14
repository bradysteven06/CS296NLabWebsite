using CS296N80sGameFansite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Repositories
{
    public interface IPlayedRepository
    {
        IQueryable<GameInfoModel> Games { get; } // Read games
        GameInfoModel GetGameByID(int id); // Returns a game
        void AddGame(GameInfoModel game); // Add a game
        void EditGame(GameInfoModel game); // Edit game info
        void DeleteGame(GameInfoModel game); // Delete game
    }
}
