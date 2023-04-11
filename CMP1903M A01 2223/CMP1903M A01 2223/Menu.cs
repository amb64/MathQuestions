using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    sealed class Menu // Class created to handle the interface between the program and the user. Handles all user input and output to the user.
    {
        private static string Q { get; set; }

        public Menu()
        {
            Console.WriteLine("____________________________________________________________________________________");
            Console.WriteLine("\nWelcome to the Maths Tutor Program!");

            if (Program.TestActive == false) // Program will not proceed if the testing commands are being carried out
            {
                WhichOption(); // Asks the user which option on the menu they'd like to select
            }
        }

        // Encapsulation
        private static void WhichOption()
        {
            while (true) // Loop that will continue until broken out of
            {
                Console.WriteLine("____________________________________________________________________________________");
                Console.WriteLine("\nPlease select from the following options:\nInstructions - 1\nDeal 3 cards - 2\nDeal 5 cards - 3\n");
                try // Exceptions used for handling erroneous input
                {
                    int Choice = Convert.ToInt32(Console.ReadLine()); // Getting input as an integer
                    if (Choice == 1)
                    {
                        new Instructions();
                    }
                    else if (Choice == 2)
                    {
                        new MathQuestion(); // Instantiating a question object to generate the question
                        Q = MathQuestion.Question;
                        Question();
                    }
                    else if (Choice == 3)
                    {
                        new CompoundQuestion();
                        //Q = CompoundQuestion.Question;
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
                Console.WriteLine("3 Cards have been dealt.\n\nHere is your question:\n");
                Console.WriteLine(Q); // Displaying the question. We also do this every time in the loop just in case they lose the question.

                // Getting user input for their answer
                Console.WriteLine("\nPlease input your answer:\n");

                try // Exceptions used for handling erroneous input
                {
                    Console.Write("-> ");
                    int Choice = Convert.ToInt32(Console.ReadLine()); // Getting input as an integer
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("\nInvalid input. Please type the number you believe is the answer and press enter.");
                }
            }

            Console.WriteLine("Cool! I will check that later.");
            Console.ReadLine();

        }
    }
}
