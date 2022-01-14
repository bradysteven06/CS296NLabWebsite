using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;
using CS296N80sGameFansite.Repositories;

namespace CS296N80sGameFansite.Controllers
{
    public class WantToPlayController : Controller
    {
        /*private WantToPlayContext context { get; set; }

        public WantToPlayController(WantToPlayContext ctx)
        {
            context = ctx;
        }*/

        IWantToPlayRepository repo;

        public WantToPlayController(IWantToPlayRepository r)
        {
            repo = r;
        }

        [HttpGet]
        public IActionResult WantToPlay()
        {
            //ViewBag.gameList = context.GameInfo.ToList();
            /*var gameList = context.GameInfo.OrderBy(m => m.Name).ToList();
            return View(gameList);*/
            var gameList = repo.Games.OrderBy(m => m.Name).ToList();
            return View(gameList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            /*ViewBag.Action = "Add";
            return View("Edit", new GameInfoModel());*/
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
            /*ViewBag.Action = "Edit";
            var game = context.GameInfo.Find(id);
            return View(game);*/
            ViewBag.Action = "Edit";
            var game = repo.GetGameByID(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(GameInfoModel game)
        {
            /*if (ModelState.IsValid)
            {
                if (game.GameID == 0)
                {
                    context.GameInfo.Add(game);
                }
                else
                {
                    context.GameInfo.Update(game);
                }
                context.SaveChanges();
                return RedirectToAction("WantToPlay", "WantToPlay");
            }
            else
            {
                // if GameId is 0 "Add" else "Edit"
                ViewBag.Action = (game.GameID == 0) ? "Add" : "Edit";
                return View(game);
            }*/
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
            /*var game = context.GameInfo.Find(id);
            return View(game);*/
            var game = repo.GetGameByID(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(GameInfoModel game)
        {
            /*context.GameInfo.Remove(game);
            context.SaveChanges();
            return RedirectToAction("WantToPlay", "WantToPlay");*/
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
