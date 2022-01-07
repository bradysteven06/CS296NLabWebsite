using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS295NTermProject.Models;

namespace CS295NTermProject.Controllers
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
            ViewBag.gameList = context.GameInfo.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult GamesPlayed(GameInfoModel model)
        {
            if (model.GameID > 0)
            {
                context.GameInfo.Update(model);
                context.SaveChanges();
            }
            else
            {
                context.GameInfo.Add(model);
                context.SaveChanges();
            }

            ViewBag.gameList = context.GameInfo.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GameInfoModel game;
            if (id > 0)
            {
                game = context.GameInfo.Find(id);
                ViewBag.button = "Save";
            }
            else
            {
                game = new GameInfoModel();
                ViewBag.button = "Add";
            }

            return View(game);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var game = context.GameInfo.Find(id);
            context.GameInfo.Remove(game);
            context.SaveChanges();

            ViewBag.gameList = context.GameInfo.ToList();
            return View("GamesPlayed");
        }

        [HttpPost]
        public IActionResult Search(GameInfoModel model)
        {
            ViewBag.gameList = context.GameInfo.Where(g => g.Name.Contains(model.Name)).ToList();
            return View();
        }
    }
}
