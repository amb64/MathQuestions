using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class CheckAnswer : IMathQ
    {
        public static float Correct { get; set; } // Public variable to store the correct answer

        public CheckAnswer(List<Card> Cards) 
        {
            Correct = 0;
            /* 
            Operators:
            1 : +
            2 : -
            3 : *
            4 : /
            */

            float Number1 = Cards[0].Value;
            float Operator = Cards[1].Suit;
            float Number2 = Cards[2].Value; // Setting all of the values

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
        }

        public void Subtract(float Number1, float Number2)
        {
            Correct = Number1 - Number2;
        }

        public void Multiply(float Number1, float Number2)
        {
            Correct = Number1 * Number2;
        }

        public void Divide(float Number1, float Number2)
        {
            Correct = Number1 / Number2;
        }

    }
}
