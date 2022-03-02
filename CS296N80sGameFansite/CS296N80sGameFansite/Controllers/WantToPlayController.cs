using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> WantToPlay()
        {
            List<WantToPlay> gameList = await repo.Games.ToListAsync<WantToPlay>();
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
        public async Task<IActionResult> Add(WantToPlay game)
        {
            if (ModelState.IsValid)
            {
                await repo.AddGameAsync(game);
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
        public async Task<IActionResult> Edit(WantToPlay game)
        {
            if (ModelState.IsValid)
            {
                await repo.EditGameAsync(game);
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
        public async Task<IActionResult> Delete(WantToPlay game)
        {
            await repo.DeleteGameAsync(game);
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
