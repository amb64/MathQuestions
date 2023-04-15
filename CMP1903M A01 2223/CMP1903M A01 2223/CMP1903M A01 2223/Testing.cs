using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing // Testing class, you can check the maths yourself with a calculator!
    {
        public Testing() // Testing class. Deals 3 cards, finds the answer, and repeats with 5 cards.
        {
            Console.WriteLine("\n**CARRYING OUT TEST COMMANDS**\n\nCreating a simple question...\n\n");

            new MathQuestion();
            List<Card> Cards = MathQuestion.CardsDealt;
            string Q = MathQuestion.Question;

            new CheckAnswer(Cards);
            float Answer = CheckAnswer.Correct;

            Console.WriteLine("-> " + Q);
            Console.WriteLine("\nThe answer is: " + Answer + " \n\n");

            Console.WriteLine("Creating a compound question...\n\n");

            new CompoundQuestion();

            List<Card> Cards2 = CompoundQuestion.CardsDealt;
            string Q2 = CompoundQuestion.Question;

            new CheckCompoundAnswer(Cards2);
            float Answer2 = CheckCompoundAnswer.Correct;

            Console.WriteLine("-> " + Q2);
            Console.WriteLine("\nThe answer is: " + Answer2 + " \n\n");

            Program.TestActive = false;
            Console.WriteLine("\n**END OF TEST COMMANDS**\nPRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }   
        
    }
}
