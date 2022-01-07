using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295NTermProject.Models
{
    public class QuestionDB
    {
        // Quiz questions
        public static Question GetQuestion(int QuestionID)
        {
            Question questionValue = new Question();
            if(QuestionID == 1)
            {
                questionValue.Text = "Mario originated as a character in which video game?";
                questionValue.Option1 = "Donkey Kong";
                questionValue.Option2 = "Battle Toads";
                questionValue.Option3 = "Legend of Zelda";
                questionValue.Option4 = "Mortal Kombat";
                questionValue.Answer = "Donkey Kong";
            }

            if(QuestionID == 2)
            {
                questionValue.Text = "Nintendo began as a company that sold which products?";
                questionValue.Option1 = "VCRs";
                questionValue.Option2 = "Playing Cards";
                questionValue.Option3 = "TVs";
                questionValue.Option4 = "Toothbrushes";
                questionValue.Answer = "Playing Cards";
            }

            if(QuestionID == 3)
            {
                questionValue.Text = "What was the first video game in the world called?";
                questionValue.Option1 = "Asteroids";
                questionValue.Option2 = "Pokemon";
                questionValue.Option3 = "Donkey Kong";
                questionValue.Option4 = "Pong";
                questionValue.Answer = "Pong";
            }

            if (QuestionID == 4)
            {
                questionValue.Text = "'Kingdom Of Hyrule' is the main setting for which classic video game franchise?";
                questionValue.Option1 = "The Legend Of Zelda";
                questionValue.Option2 = "Super Mario Bros";
                questionValue.Option3 = "Pokemon";
                questionValue.Option4 = "Metal Gear Solid";
                questionValue.Answer = "The Legend Of Zelda";
            }

            if (QuestionID == 5)
            {
                questionValue.Text = "In the 'Pac-Man' video game, what's the name of the orange ghost?";
                questionValue.Option1 = "Fry";
                questionValue.Option2 = "Harry";
                questionValue.Option3 = "Clyde";
                questionValue.Option4 = "Blinky";
                questionValue.Answer = "Clyde";
            }

            if (QuestionID == 6)
            {
                questionValue.Text = "What was Mario's first job?";
                questionValue.Option1 = "Plumber";
                questionValue.Option2 = "Carpenter";
                questionValue.Option3 = "Electrician";
                questionValue.Option4 = "Wizard";
                questionValue.Answer = "Carpenter";
            }

            if (QuestionID == 7)
            {
                questionValue.Text = "When was 'Pong' released?";
                questionValue.Option1 = "November 29, 1999";
                questionValue.Option2 = "November 29, 1981";
                questionValue.Option3 = "November 29, 1972";
                questionValue.Option4 = "November 29, 2020";
                questionValue.Answer = "November 29, 1972";
            }

            if (QuestionID == 8)
            {
                questionValue.Text = "What year was Nintendo founded?";
                questionValue.Option1 = "1750";
                questionValue.Option2 = "1995";
                questionValue.Option3 = "1889";
                questionValue.Option4 = "1980";
                questionValue.Answer = "1889";
            }

            if (QuestionID == 9)
            {
                questionValue.Text = "What does the name Nintendo mean?";
                questionValue.Option1 = "Leave luck to heaven";
                questionValue.Option2 = "First come first served";
                questionValue.Option3 = "Don't cound your chickens before they hatch";
                questionValue.Option4 = "Shut up and take my money";
                questionValue.Answer = "Leave luck to heaven";
            }

            if (QuestionID == 10)
            {
                questionValue.Text = "What kind of food was the character Pac Man modelled on?";
                questionValue.Option1 = "Apple";
                questionValue.Option2 = "Orange";
                questionValue.Option3 = "Pizza";
                questionValue.Option4 = "Walnut";
                questionValue.Answer = "Pizza";
            }

            /*if (QuestionID == 3)
            {
                questionValue.Text = "";
                questionValue.Option1 = "";
                questionValue.Option2 = "";
                questionValue.Option3 = "";
                questionValue.Option4 = "";
                questionValue.Answer = "";
            }*/

            return questionValue;
        }
    }
}
