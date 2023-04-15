using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // Displaying a non-interactive tutorial / set of instructions to the user
    public class Instructions
    {
        public Instructions() 
        {
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nWelcome to the instructions!\n\nIn this program, a virtual pack of cards is shuffled.\nThen, depending on your choice, either 3 or 5 cards are dealt.");
            Console.WriteLine("\n\nFrom these cards, a maths question is generated, just like this one:\n");

            new MathQuestion();
            List<Card> Cards = MathQuestion.CardsDealt;
            string Q = MathQuestion.Question;

            new CheckAnswer(Cards);
            float Answer = CheckAnswer.Correct;

            Console.WriteLine("-> " + Q);

            Console.WriteLine("\nYou would then type the answer to this question, and the program will tell you if you are correct or not.");
            Console.WriteLine("\nIn this case, the answer is: " + Answer + " \n\n");

            Console.WriteLine(@"There is a statistics file in the CMP1903M A01 2223\\CMP1903M A01 2223\\bin\\Debug folder.");
            Console.WriteLine("This file tells you how many questions you have gotten correct in the top line,\nand in the bottom line, how many you have answered total.");

            Console.WriteLine("\n\nPress enter to return to the main menu...");
            Console.ReadLine();
        }   
    }
}
