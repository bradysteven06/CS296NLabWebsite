using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;

namespace CS296N80sGameFansite.Controllers
{
    public class GamesPlayedController : Controller
    {
        private GamesPlayedContext context { get; set; }

        public GamesPlayedController(GamesPlayedContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult GamesPlayed()
        {
            //ViewBag.gameList = context.GameInfo.ToList();
            var gameList = context.GameInfo.OrderBy(m => m.Name).ToList();
            return View(gameList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new GameInfoModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var game = context.GameInfo.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(GameInfoModel game)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("GamesPlayed", "GamesPlayed");
            }
            else
            {
                ModelState.AddModelError("", "Please correct all errors"); // validation error message model level

                // if GameId is 0 "Add" else "Edit"
                ViewBag.Action = (game.GameID == 0) ? "Add" : "Edit";
                return View(game);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = context.GameInfo.Find(id);
            return View(game);
        }

        [HttpPost]
        public IActionResult Delete(GameInfoModel game)
        {
            context.GameInfo.Remove(game);
            context.SaveChanges();
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
