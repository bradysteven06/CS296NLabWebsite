using CS296N80sGameFansite.Controllers;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Tests
{
    public class PlayedTests
    {
        [Fact]
        public void AddTest()
        {
            // Arrange
            var fakeRepo = new FakePlayedRepository();
            var controller = new GamesPlayedController(fakeRepo);
            var game = new Played();

            // Adds a game
            // Act
            controller.Add(game);

            // Checks that there is one game in list
            // Assert
            var repoGameList = fakeRepo.Games.ToList();
            Assert.True(1 == repoGameList.Count());
        }

        [Fact]
        public void EditTest()
        {
            // Adds a game
            // Arrange
            var fakeRepo = new FakePlayedRepository();
            var controller = new GamesPlayedController(fakeRepo);
            var game = new Played();
            controller.Add(game);

            // Edits game values saving new values
            // Act
            game.Name = "Test";
            game.Year = 1984;
            game.Platform = "Testrix";
            controller.Edit(game);

            // Checks value of name for game
            // Assert
            var repoGameList = fakeRepo.Games.ToList();
            Assert.True("Test" == repoGameList[0].Name);
        }

        [Fact]
        public void DeleteTest()
        {
            // Adds 3 games
            // Arrange
            var fakeRepo = new FakePlayedRepository();
            var controller = new GamesPlayedController(fakeRepo);
            var game = new Played();
            var game2 = new Played();
            var game3 = new Played();
            controller.Add(game);
            controller.Add(game2);
            controller.Add(game3);

            // Deletes second game added
            // Act
            fakeRepo.DeleteGame(game2);

            // checks that 2 games left and that they are first and third game added
            // Assert
            var repoGameList = fakeRepo.Games.ToList();
            Assert.True(2 == repoGameList.Count());
            Assert.True(0 == repoGameList[0].GameID);
            Assert.True(2 == repoGameList[1].GameID);
        }

    }
}
