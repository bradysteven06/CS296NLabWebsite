using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;

namespace CS296N80sGameFansite.Controllers
{
    public class GamesPlayedController : Controller
    {
        IPlayedRepository repo;

        public GamesPlayedController(IPlayedRepository r)
        {
            repo = r;
        }

        [HttpGet]
        public IActionResult GamesPlayed()
        {
            var gameList = repo.Games.OrderBy(m => m.Name).ToList();
            return View(gameList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var game = new GameInfoModel();
            return View(game);
        }

        [HttpPost]
        public IActionResult Add(GameInfoModel game)
        {
            if (ModelState.IsValid)
            {
                repo.AddGame(game);
                return RedirectToAction("GamesPlayed", "GamesPlayed");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors"); // validation error message model level
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var game = repo.GetGameByID(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(GameInfoModel game)
        {
            if (ModelState.IsValid)
            {
                repo.EditGame(game);
                return RedirectToAction("GamesPlayed", "GamesPlayed");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors"); // validation error message model level
                return View(game);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = repo.GetGameByID(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(GameInfoModel game)
        {
            repo.DeleteGame(game);
            return RedirectToAction("GamesPlayed", "GamesPlayed");
        }

        /* 
         [HttpPost]
         public IActionResult Search(GameInfoModel model)
         {
             ViewBag.gameList = context.GameInfo.Where(g => g.Name.Contains(model.Name)).ToList();
             return View();
         }*/
    }
}
