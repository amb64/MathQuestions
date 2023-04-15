using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class CompoundQuestion : QuestionGeneration, IPack // Essentially the same as the regular question but overrides the cardstodeal integer with 5 instead of 3. and will generate the string question with 5 instead of 3 cards
    {
        protected override int CardsToDeal // Overriding the cardstodeal value with 3 as this is a question with only 1 operator
        {
            get { return 5; }
        }

        private List<Card> pack { get; set; } // Pack variable, stores every card
        private List<string> Operators; // List that stores the operators as strings
        public static List<Card> CardsDealt { get; set; } // List that stores the cards dealt, to be used for the question. Public so it can be accessed later when checking the answer
        public static string Question { get; set; } // String that stores the question. Public so it can be accessed by the menu and outputted to the user

        public CompoundQuestion()
        {
            Operators = new List<string> { "", "+", "-", "×", "÷" }; // The first spot is kept empty just so we can easily refer to the operators with the suit numbers and don't need to worry about index

            CreatePack(); // Creating the pack
            ShufflePack(); // Shuffling the pack
            CardsDealt = DealCards(pack, CardsToDeal); // Dealing cards
            GenerateQuestion(CardsDealt); // Creating the question
        }
        public void CreatePack() // Instantiating a new pack and storing it
        {
            new Pack();
            pack = Pack.pack;
        }

        public void ShufflePack() // Shuffling the pac
        {
            pack = Pack.ShuffleCardPack(pack);
        }

        public List<Card> DealCards(List<Card> pack, int CardsToDeal) // Dealing cards and storing them in a list
        {
            List<Card> Cards = Pack.DealCard(CardsToDeal, pack);
            return Cards;
        }

        public override void GenerateQuestion(List<Card> CardsDealt) // Generating a question using only 1 operator
        {
            int Number1 = CardsDealt[0].Value;
            int Operator1 = CardsDealt[1].Suit;
            int Number2 = CardsDealt[2].Value; // Setting all of the values
            int Operator2 = CardsDealt[3].Suit;
            int Number3 = CardsDealt[4].Value;

            Question = Number1.ToString(); // Generating a string of the question. Splitting with spaces to make the question more readable.
            Question += " ";
            Question += (Operators[Operator1]);
            Question += " ";
            Question += Number2.ToString();
            Question += " ";
            Question += (Operators[Operator2]);
            Question += " ";
            Question += Number3.ToString();

        }
    }
}
