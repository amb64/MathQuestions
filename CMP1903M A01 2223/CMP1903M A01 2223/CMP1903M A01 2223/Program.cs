using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CMP1903M_A01_2223
{
    class Program // Actually runs the program.
    {
        public static bool TestActive { get; set; }
        static void Main()
        {
            TestActive = true; // COMMENT THIS LINE TO REMOVE TESTING COMMANDS

            new Menu();
            new Testing(); // COMMENT THIS LINE TO REMOVE TESTING COMMANDS

            InfiniteMenus();
            
        }

        private static void InfiniteMenus()
        {
            while (true)
            {
                new Menu();
            }
        }
    }
}
