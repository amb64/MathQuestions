using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public abstract class QuestionGeneration
    {
        protected abstract int CardsToDeal { get; }
        public abstract void GenerateQuestion(List<Card> CardsDealt);
    }
}
