using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // interface that ensures maths classes implement methods for the four operations
    public interface IMathQ
    {
        void Add(float Number1, float Number2);
        void Subtract(float Number1, float Number2);
        void Multiply(float Number1, float Number2);
        void Divide(float Number1, float Number2);

    }
}
