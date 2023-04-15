using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class CheckCompoundAnswer : AnswerGeneration , IMathQ
    {
        public static float Correct { get; set; } // Public variable to store the correct answer
        private static bool Op2 = false; // Bool used to check whether this is the 2nd operation or not.
        private static bool Left = false; // Bool used for 2nd operations, as we might have a situation where the program does 10 - 4 instead of 4 - 10
        
        public CheckCompoundAnswer(List<Card> Cards)
        {
            Correct = 0;
            Op2 = false;
            Left = false; // Resetting these variables
            
            CheckTheAnswer(Cards);
        }

        // Override to check the answer, but for a compound question
        public override void CheckTheAnswer(List<Card> Cards)
        {
            /* 
            Operators:
            1 : +
            2 : -
            3 : *
            4 : /
            */

            float Number1 = Cards[0].Value;
            float Operator1 = Cards[1].Suit;
            float Number2 = Cards[2].Value; // Setting all of the values
            float Operator2 = Cards[3].Suit;
            float Number3 = Cards[4].Value;

            //BIDMAS. Works as D = M -> A = S. 
            // (I hope this BIDMAS implementation is right, because I originally coded it as D > M > A > S, whoever taught me this in primary school is a liar!)

            while (true)
            {
                if (Operator1 == 4 || Operator1 == 3 || Operator2 == 4 || Operator2 == 3) // First check if any operator is a division or multiplication
                {
                    if (Operator1 == 2 || Operator1 == 1 || Operator2 == 2 || Operator2 == 1) // Then check if any operator is addition or subtraction
                    {
                        if (Operator1 == 1 || Operator1 == 2) // If the first operator is addition or subtraction, we need to calculate the 2nd half first
                        {
                            switch (Operator2) // Perform the correct operation
                            {
                                case 3:
                                    Multiply(Number2, Number3);
                                    break;
                                case 4:
                                    Divide(Number2, Number3);
                                    break;
                            }

                            WhatOperator(Operator1, Number1, Correct); // We pass Number1 and then Correct as we did the right side of the calculation first. So in the case of 5 - 3 / 1, we want to make sure it does 5 - 3 not 3 - 5!
                            break;
                        }
                    }
                }

                // In all other situations, we work from left to right!! ^^
                WhatOperator(Operator1, Number1, Number2);
                WhatOperator(Operator2, Correct, Number3); // Here we pass the current value of Correct instead of the first number so we can use it in the operation!!
                break;
            }
        }

        // Method to perform a switch/case statement to figure out which operation to perform, so we can reuse this code often!
        private void WhatOperator(float Operator, float Number1, float Number2)
        {
            switch (Operator)
            {
                case 1: 
                    Add(Number1, Number2); 
                    break;
                case 2:
                    Subtract(Number1, Number2);
                    break;
                case 3:
                    Multiply(Number1, Number2);
                    break;
                case 4:
                    Divide(Number1, Number2);
                    break;
            }
        }
        public void Add(float Number1, float Number2)
        {
            Correct = Number1 + Number2;

            //Console.WriteLine("Operation ADD\n" + Number1 + " + " + Number2 + " = " + Correct);
        }

        public void Subtract(float Number1, float Number2)
        {
            Correct = Number1 - Number2;

            //Console.WriteLine("Operation 1 SUBTRACT\n" + Number1 + " - " + Number2 + " = " + Correct);
        }

        public void Multiply(float Number1, float Number2)
        {
            Correct = Number1 * Number2;

            //Console.WriteLine("Operation 1 MULTIPLY\n" + Number1 + " * " + Number2 + " = " + Correct);
        }

        public void Divide(float Number1, float Number2)
        {
            Correct = Number1 / Number2;

            //Console.WriteLine("Operation 1 DIVIDE\n" + Number1 + " / " + Number2 + " = " + Correct);
        }




    }
}
