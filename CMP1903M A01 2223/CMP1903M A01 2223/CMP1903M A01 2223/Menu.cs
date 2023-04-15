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
        private static List<Card> Cards { get; set; } // Stores the cards dealt
        private static float Answer = 0;
        private static float Correct = 0;
        private static string[] Stats;

        public Menu()
        {
            Choice = 0; // Resetting the choice variable

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
                Console.WriteLine("\nPlease select from the following options:\n\nInstructions - 1\nDeal 3 cards - 2\nDeal 5 cards - 3\nView Statistics - 4\nQuit - 5\n");
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
                    else if (Choice == 4)
                    {
                        new StatsFile();
                        Stats = StatsFile.ReadFromFile(); // Getting the lines from the file
                        ViewStats(Stats);
                    }
                    else if (Choice == 5)
                    {
                        Console.WriteLine("____________________________________________________________________________________");
                        Console.WriteLine("\nGoodbye!\n\nPress enter to quit the program.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else // If the user inputted another number, a message is displays and the loop continues
                    {
                        Console.WriteLine("\nInvalid input. Please type the corresponding number and press enter.");
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
                Console.WriteLine("\nCards have been dealt.\n\nHere is your question:\n");
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

            if (Answer == Correct)
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

        // Updates the statistics file
        private static void UpdateStatistics(bool IsCorrect)
        {
            StatsFile.WriteToFile(IsCorrect);

            while (true)
            {
                Console.WriteLine("\nWould you like to deal again or return to the main menu?\n\nDeal again - 1\nReturn to the main menu - 2\n");

                try // Exceptions used for handling erroneous input
                {
                    int Option = Convert.ToInt32(Console.ReadLine()); // Getting input as an integer
                    if (Option == 1)
                    {
                        switch (Choice)
                        {
                            case 2:
                                new MathQuestion(); // Instantiating a question object to generate the question
                                Q = MathQuestion.Question;
                                Cards = MathQuestion.CardsDealt;
                                Question();
                                break;
                            case 3:
                                new CompoundQuestion();
                                Q = CompoundQuestion.Question;
                                Cards = CompoundQuestion.CardsDealt;
                                Question();
                                break;
                        }

                        break;
                    }
                    else if (Option == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("____________________________________________________________________________________");
                        Console.WriteLine("\nInvalid input. Please type the corresponding number and press enter.");
                        continue;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("____________________________________________________________________________________");
                    Console.WriteLine("\nInvalid input. Please type the corresponding number and press enter.");
                }
            }
        }

        private static void ViewStats(string[] Stats)
        {
            Console.WriteLine("\n____________________________________________________________________________________");
            Console.WriteLine("\nWelcome to the statistics page!\n\n");

            Console.WriteLine("Correct answers -> " + Stats[0]);
            Console.WriteLine("\nTotal number of questions answered -> " + Stats[1]);

            Console.WriteLine("\n\nPress enter to return to the main menu...");
            Console.ReadLine();
        }
    }
}
