using System;
using Xunit;
using Moq;
using CS295NTermProject.Models;
using CS295NTermProject.Controllers;

namespace CS295NTermProjectTests
{
    public class QuizTests
    {
        [Fact]
        public void IsAnswerTrue()
        {
            QuizModel testQuiz = new QuizModel();
            testQuiz.Answer = "test1";
            testQuiz.UAnswer = "test1";

            Assert.True(testQuiz.IsAnswerTrue());

            testQuiz.UAnswer = "test2";
            Assert.False(testQuiz.IsAnswerTrue());

        }

        [Fact]
        public void GetScore()
        {
            QuizModel testQuiz = new QuizModel();
            testQuiz.NumCorrect = 5;
            testQuiz.NumWrong = 5;

            Assert.Equal(testQuiz.GetScore(), "You got " + 5 + " correct and " + 5 + " wrong.");

        }

        [Fact]
        public void GetQuestion()
        {
            Question questionTest = new Question();
            questionTest = QuestionDB.GetQuestion(1);

            Assert.Equal("Mario originated as a character in which video game?", questionTest.Text);
            Assert.Equal("Donkey Kong", questionTest.Option1);
            Assert.Equal("Battle Toads", questionTest.Option2);
            Assert.Equal("Legend of Zelda", questionTest.Option3);
            Assert.Equal("Mortal Kombat", questionTest.Option4);
            Assert.Equal("Donkey Kong", questionTest.Answer);

        }
    }
}
