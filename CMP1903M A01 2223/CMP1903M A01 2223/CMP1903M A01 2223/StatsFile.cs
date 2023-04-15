using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // Class to write to the stats.txt file in the path CMP1903M A01 2223\CMP1903M A01 2223\bin
    public class StatsFile
    {
        private static string Filename = "stats.txt";

        public static void WriteToFile(bool Correct)
        {
            string[] Lines = File.ReadAllLines(Filename); // Reads from the file

            if (Correct ==  true)
            {
                int Num = int.Parse(Lines[0]);
                Num += 1;
                string Str = Num.ToString();
                Lines[0] = Str; // Converting the first number in the file to an integer, adding one, and converting it back to a string and then adding it back into the array
            }

            int Num2 = int.Parse(Lines[1]);
            Num2 += 1;
            string Str2 = Num2.ToString();
            Lines[1] = Str2;
            // Adds one to the 2nd line of the file, as this increments the total questions answered counter

            File.WriteAllLines(Filename, Lines); // Write to the file
        }

        public static string[] ReadFromFile() // Simply reads the 2 lines from the file and returns it so it can be displayed
        {
            string[] Lines = File.ReadAllLines(Filename);

            return Lines;
        }
    }
}
