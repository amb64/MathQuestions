using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        // Creating a new list to store the Card objects. Public so it can be used by the Program file.
        public static List<Card> pack { get; set; }

        public Pack()
        {
            pack = new List<Card>();

            //Initialise the card pack here
            for (int a = 0; a < 4; a++) // Iterating through the 4 suits
            {
                for (int b = 0; b < 13; b++) // Iterating through the 13 values
                {
                    Card Newcard = new Card // Creating a new card
                    {
                        Value = b + 1, // Setting the value and suit of this card. Need to plus one due to the offset with indexes
                        Suit = a + 1
                    };
                    pack.Add(Newcard); // Adds this card to the list of Cards (the pack of cards)
                    
                }
            }
        }


        public static List<Card> ShuffleCardPack(List<Card> pack)
        {
            //Shuffles the pack based on the type of shuffle. Is also passed the list of Card objects.

            Random Rand = new Random(); // Creating a new random object

            int n = 1; // Counter for the while loop

            while (n <= 7) // Performing the shuffle 7 times so it is random
            {
                int b = Rand.Next(0, 52); // Randomly generates a number between 1 and 52 (upper exclusive) to be used as the "midpoint", where the deck would be split into two

                Queue<Card> HalfA = new Queue<Card>(); // Creates two queues that store half of the pack of cards. The pack is split using the midpoint, b.
                for (int a = 0; a < b; a++) // From the first card to the card before the midpoint (the condition is a < b because the upper bound is exclusive!)
                {
                    HalfA.Enqueue(pack[a]);
                }
                Queue<Card> HalfB = new Queue<Card>();
                for (int a = b; a < 52; a++) // From the midpoint card to the end of the pack
                {
                    HalfB.Enqueue(pack[a]);
                }

                int WhichSide = Rand.Next(0, 2); // Generates which side of the new deck will be put on top
                List<Card> NewPack = new List<Card>(); // A list is created to store the new, shuffled pack

                if (WhichSide == 0) // First half first
                {
                    for (int a = 0; a < 52; a++) // This loop will dequeue a card in the relevant half and then add it to the NewPack list, alternating between halves.
                    {
                    try // Exceptions are used here because as the midpoint is random, one half of the deck will be bigger. If one side has run out of cards, it will not cause the program to crash
                    {
                        Card temp = HalfA.Dequeue();
                        NewPack.Add(temp);
                    }
                    catch (System.InvalidOperationException) { }
                    try
                    {
                        Card temp = HalfB.Dequeue();
                        NewPack.Add(temp);
                    }
                    catch (System.InvalidOperationException) { }

                    }
                }
                else if (WhichSide == 1) // Second half first
                {
                    for (int a = 0; a < 52; a++) // This loop will dequeue a card in the relevant half and then add it to the NewPack list, alternating between halves.
                    {
                        try // Exceptions are used here because as the midpoint is random, one half of the deck will be bigger. If one side has run out of cards, it will not cause the program to crash
                        {
                            Card temp = HalfB.Dequeue();
                            NewPack.Add(temp);
                        }
                        catch (System.InvalidOperationException) { }
                        try
                        {
                            Card temp = HalfA.Dequeue();
                            NewPack.Add(temp);
                        }
                        catch (System.InvalidOperationException) { }
                    }
                }
                    

                pack = NewPack; // The original pack of cards is replaced with the now shuffled NewPack list.

                n++; // n is incremented so the shuffle occurs again until it has been done 7 times.

            }

            /*Menu.PackOfCards.pack = pack; // This line is required because for some reason the pack is only updated locally.
            if (Program.TestActive == true) // If testing is active, this line is required to update the pack in the testing class.
            {
                Testing.TestingPack.pack = pack;
            }*/

            return pack;
        }
    
        public static List<Card> DealCard(int amount, List<Card> pack)
        {
            //Deals the number of cards specified by 'amount'

            List<Card> DealtCards = new List<Card>();

            for (int a = 0; a < amount; a++)
            {
                try // Exceptions are used as if the deck is empty, no more cards can be dealt
                {
                    Card DealtCard = pack.Last(); // Deals and stores the last card in the pack, to simulate taking a card off of the top of the deck
                    pack.Remove(DealtCard); // Removes the card from the pack

                    DealtCards.Add(DealtCard); // Adds the dealt card to the list
                }
                catch (System.InvalidOperationException) { }
            }

            return DealtCards; // Returns the cards that were dealt.
        }


        // Additional method created to testing purposes to print out all of the card after being shuffled.
        public static void ViewPack(List<Card> pack)
        {
            // For testing purposes. Prints out all the cards and the total number of cards

            foreach (var card in pack)
            {
                Console.WriteLine("Suit:" + card.Suit + "Value:" + card.Value);
            }
            Console.WriteLine("Number of cards: " + pack.Count);
            Console.ReadLine();
        }

    }
}
            
