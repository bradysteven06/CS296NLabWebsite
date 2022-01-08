using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS296N80sGameFansite.Models
{
    public class QuizModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string UAnswer { get; set; }
        public int QuestionID { get; set; }
        public int NumCorrect { get; set; }
        public int NumWrong { get; set; }

        public bool IsAnswerTrue()
        {
            return UAnswer == Answer;
        }

        public string GetScore()
        {
            string correct = "You got " + NumCorrect + " correct and " + NumWrong + " wrong.";

            return correct;
        }

    }
}
