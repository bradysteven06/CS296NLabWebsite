using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace CS296N80sGameFansite.Controllers
{
    public class WantToPlayController : Controller
    {
        IWantToPlayRepository repo;

        public WantToPlayController(IWantToPlayRepository r)
        {
            repo = r;
        }

        [Authorize]
        public IActionResult WantToPlay()
        {
            var gameList = repo.Games.OrderBy(m => m.Name).ToList();
            return View(gameList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var game = new WantToPlay();
            return View(game);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(WantToPlay game)
        {
            if (ModelState.IsValid)
            {
                repo.AddGame(game);
                return RedirectToAction("WantToPlay", "WantToPlay");
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
            var game = repo.GetGameByID(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(WantToPlay game)
        {
            if (ModelState.IsValid)
            {
                repo.EditGame(game);
                return RedirectToAction("WantToPlay", "WantToPlay");
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
        public IActionResult Delete(WantToPlay game)
        {
            repo.DeleteGame(game);
            return RedirectToAction("WantToPlay", "WantToPlay");
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
