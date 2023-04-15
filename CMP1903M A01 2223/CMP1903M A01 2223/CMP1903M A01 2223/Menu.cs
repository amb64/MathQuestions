using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    sealed class Menu // Class created to handle the interface between the program and the user. Handles all user input and output to the user.
    {
        private static int Choice = 0; // Setting the choice variable so we can keep track of whether the user selected a 3 or 5 card problem
        private static string Q { get; set; } // Stores the question generated as a string
        private static List<Card>  Cards { get; set; } // Stores the cards dealt
        private static float Answer = 0;
        private static float Correct = 0;

        public Menu()
        {
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nWelcome to the Maths Tutor Program!");

            if (Program.TestActive == false) // Program will not proceed if the testing commands are being carried out
            {
                WhichOption(); // Asks the user which option on the menu they'd like to select
            }
        }

        private static void WhichOption()
        {
            while (true) // Loop that will continue until broken out of
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\nPlease select from the following options:\nInstructions - 1\nDeal 3 cards - 2\nDeal 5 cards - 3\n");
                try // Exceptions used for handling erroneous input
                {
                    Choice = Convert.ToInt32(Console.ReadLine()); // Getting input as an integer
                    if (Choice == 1)
                    {
                        new Instructions();
                    }
                    else if (Choice == 2)
                    {
                        new MathQuestion(); // Instantiating a question object to generate the question
                        Q = MathQuestion.Question;
                        Cards = MathQuestion.CardsDealt;
                        Question();
                    }
                    else if (Choice == 3)
                    {
                        new CompoundQuestion();
                        Q = CompoundQuestion.Question;
                        Cards = CompoundQuestion.CardsDealt;
                        Question();
                    }
                    else // If the user inputted a number over 3, a message is displays and the loop continues
                    {
                        Console.WriteLine("\nInvalid input. Please type the number of the shuffle and press enter.");
                        continue;
                    }
                    break; // Breaks out of the loop
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please type the corresponding number and press enter."); // Notifies the user that their input was invalid if they didn't enter a number
                }

            }

        }

        private static void Question()
        {
            while (true)
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("Cards have been dealt.\n\nHere is your question:\n");
                Console.WriteLine(Q); // Displaying the question. We also do this every time in the loop just in case they lose the question.

                // Getting user input for their answer
                Console.WriteLine("\nPlease input your answer:\n");

                try // Exceptions used for handling erroneous input
                {
                    Console.Write("-> ");
                    Answer = Single.Parse(Console.ReadLine()); // Getting input as a float
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please type the number you believe is the answer and press enter.");
                }
            }

            switch (Choice)
            {
                case 2:
                    new CheckAnswer(Cards);
                    Correct = CheckAnswer.Correct;
                    break;
                case 3:
                    new CheckCompoundAnswer(Cards);
                    Correct = CheckCompoundAnswer.Correct;
                    break;
            }

            bool IsCorrect = false;

            if (Answer  == Correct)
            {
                IsCorrect = true;
                CorrectAnswer(Answer);
            }
            else
            {
                IncorrectAnswer(Correct, Answer);
            }

            UpdateStatistics(IsCorrect);

        }

        private static void CorrectAnswer(float Answer)
        {
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nWell done!\n\nYour answer of " + Answer + " is correct!");
        }

        private static void IncorrectAnswer(float Correct, float Answer)
        {
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nUnfortunately, your answer of " + Answer + " is incorrect.\n\nThe correct answer is: " + Correct);
        }

        private static void UpdateStatistics(bool IsCorrect)
        {
            Console.ReadLine();
        }
    }
}
