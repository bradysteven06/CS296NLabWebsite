using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS296N80sGameFansite.Models;

namespace CS296N80sGameFansite.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Games()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            ViewBag.numCorrect = 0;
            ViewBag.numWrong = 0;
            ViewBag.qid = 1;

            //Get Question Text
            Question question = QuestionDB.GetQuestion(ViewBag.qid);
            ViewBag.QuestionText = question.Text;
            ViewBag.Option1 = question.Option1;
            ViewBag.Option2 = question.Option2;
            ViewBag.Option3 = question.Option3;
            ViewBag.Option4 = question.Option4;

            return View();
        }

        [HttpPost]
        public IActionResult Quiz(QuizModel inModel)
        {
            /*ViewBag.numCorrect = quizState.NumCorrect;
            ViewBag.numWrong = quizState.NumWrong;*/
            ViewBag.numCorrect = inModel.NumCorrect;
            ViewBag.numWrong = inModel.NumWrong;
            ViewBag.qid = inModel.QuestionID + 1;
            inModel.Answer = QuestionDB.GetQuestion(inModel.QuestionID).Answer;


            if (inModel.IsAnswerTrue())
            {
                ViewBag.numCorrect++;
            }
            else
            {
                ViewBag.numWrong++;
            }


            //Get Question Text
            Question question = QuestionDB.GetQuestion(ViewBag.qid);
            ViewBag.QuestionText = question.Text;
            ViewBag.Option1 = question.Option1;
            ViewBag.Option2 = question.Option2;
            ViewBag.Option3 = question.Option3;
            ViewBag.Option4 = question.Option4;

            ModelState.Clear();

            if (ViewBag.qid > 10)
            {
                inModel.NumCorrect = ViewBag.numCorrect;
                inModel.NumWrong = ViewBag.numWrong;
                ViewBag.Result = inModel.GetScore();
                
                return View("QuizResult");
            }

            return View();
        }

    
    }
}
