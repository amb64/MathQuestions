using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class CheckCompoundAnswer : IMathQ
    {
        public static float Correct { get; set; } // Public variable to store the correct answer
        private static bool Op2 = false; // Bool used to check whether this is the 2nd operation or not.
        private static bool Left = false; // Bool used for 2nd operations, as we might have a situation where the program does 10 - 4 instead of 4 - 10
        public CheckCompoundAnswer(List<Card> Cards)
        {
            Correct = 0;
            Op2 = false;
            Left = false;
            /* 
            Operators:
            1 : +
            2 : -
            3 : *
            4 : /
            BIDMAS
            */

            float Number1 = Cards[0].Value;
            float Operator1 = Cards[1].Suit;
            float Number2 = Cards[2].Value; // Setting all of the values
            float Operator2 = Cards[3].Suit;
            float Number3 = Cards[4].Value;

            // BIDMAS
            /*if (Operator1 == 4 || Operator2 == 4) // If either operator is divide, perform that first.
            {
                if (Operator1 == 4) // If the first one is divide, we divide passing number 1 and number 2
                {
                    Divide(Number1, Number2); // First operation
                    WhatOperator(Operator2, Number3); // Second operation
                }
                else // The second operator is divide. so we will pass number 2 and number 3, then number 1 for the 2nd operation
                {
                    Divide(Number2, Number3); // First operation
                    Left = true;
                    WhatOperator(Operator1, Number1); // Second operation
                }
            }
            else if (Operator1 == 3 || Operator2 == 3) // If there are no divides, look for multiplies, and do that first
            {
                if (Operator1 == 3) 
                {
                    Multiply(Number1, Number2); // First operation
                    WhatOperator(Operator2, Number3); // Second operation
                }
                else 
                {
                    Multiply(Number2, Number3); // First operation
                    Left = true;
                    WhatOperator(Operator1, Number1); // Second operation
                }
            }
            else if (Operator1 == 1 || Operator2 == 1) // If there are no divides or multiplies, look for adds, and do that first
            {
                if (Operator1 == 1)
                {
                    Add(Number1, Number2); // First operation
                    WhatOperator(Operator2, Number3); // Second operation
                }
                else
                {
                    Add(Number2, Number3); // First operation
                    Left = true;
                    WhatOperator(Operator1, Number1); // Second operation
                }
            }
            else // Then there are 2 subtracts!
            {
                Subtract(Number1, Number2);
                Op2 = true;
                Subtract(Number3, Number3);
            }*/

            //BIDMAS. Works as D = M -> A = S. 
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

                            //Left = true; // Set left as true so order sensitive operations are correct
                            //Op2 = true;  // We are now calculating the 2nd operation

                            WhatOperator(Operator1, Number1, Correct); // We pass the same number twice becaue that's the only one left to calculate
                            break;
                        }

                    }

                }

                WhatOperator(Operator1, Number1, Number2);
                WhatOperator(Operator2, Correct, Number3);
                break;
            }

            

            // In all other situations, we will work from left to right!

            

        }

        // Method to perform a switch/case statement to calculate the second operation
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
            // If this is the second operation, we'll just perform the operation using the 3rd number card drawn originally (named number1 here)
            // Example: 6 / 1 + 4. Division first, so 6/1 = 6. Correct = 6. Then we need to add, so we come to this method and just add 4 to Correct, which is 10 now!
            /*if (Op2 == true) 
            {
                Correct += Number1;
            }
            else // If this is the first operation, just perform the simple calculation
            {
                Correct += Number1 + Number2;
            }*/

            Correct = Number1 + Number2;

            if (Op2 == false)
            {
                Console.WriteLine("Operation 1 ADD\n" +  Number1 + " + " + Number2 + " = " + Correct);
            }
            else
            {
                Console.WriteLine("Operation 2 ADD\n" + "Correct = " + Correct);
            }
        }

        public void Subtract(float Number1, float Number2)
        {
            // Subtraction and division are sensitive based on their order. So we use left to ensure they are carried out correctly!
            /*if (Op2 == true)
            {
                if (Left == true)
                {
                    Correct = Number1 - Correct;
                }
                else
                {
                    Correct -= Number1;
                }
            }
            else 
            {
                Correct += Number1 - Number2;
            }*/

            Correct = Number1 - Number2;

            if (Op2 == false)
            {
                Console.WriteLine("Operation 1 SUBTRACT\n" + Number1 + " - " + Number2 + " = " + Correct);
            }
            else
            {
                Console.WriteLine("Operation 2 SUBTRACT\n" + "Correct = " + Correct);
            }
        }

        public void Multiply(float Number1, float Number2)
        {
            /*if (Op2 == false)
            {
                Correct += Number1 * Number2;
            }
            else
            {
                Correct *= Number1;
            }*/

            Correct = Number1 * Number2;

            if (Op2 == false)
            {
                Console.WriteLine("Operation 1 MULTIPLY\n" + Number1 + " * " + Number2 + " = " + Correct);
            }
            else
            {
                Console.WriteLine("Operation 2 MULTIPLY\n" + "Correct = " + Correct);
            }
        }

        public void Divide(float Number1, float Number2)
        {
            // Subtraction and division are sensitive based on their order. So we use left to ensure they are carried out correctly!
            /*if (Op2 == true)
            {
                if (Left == true)
                {
                    Correct = Number1 / Correct;
                }
                else
                {
                    Correct /= Number1;
                }
            }
            else
            {
                Correct += Number1 / Number2;
            }*/

             Correct = Number1 / Number2;

            if (Op2 == false)
            {
                Console.WriteLine("Operation 1 DIVIDE\n" + Number1 + " / " + Number2 + " = " + Correct);
            }
            else
            {
                Console.WriteLine("Operation 2 DIVIDE\n" + "Correct = " + Correct);
            }
        }




    }
}
