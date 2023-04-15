using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // Interface used to ensure that a pack of cards is instantiated and shuffled where needed, as well as dealt
    public interface IPack
    {
        void CreatePack();
        void ShufflePack();
        List<Card> DealCards(List<Card> pack, int CardsToDeal);
    }
}
