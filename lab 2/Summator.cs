using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Summator
    {
        private int[] liczby = [];

        public int Suma()
        {
            return liczby.Sum();
        }

        public int SumaPodziel2()
        {
            return liczby.Where(x => x % 2 == 0).Sum();
        }

        public int IleElementow()
        {
            return liczby.Length;
        }

        public void PrintAll()
        {
            foreach (int item in liczby)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintIndexRange(int lowIndex, int highIndex)
        {
            for (int i = lowIndex; i <= highIndex; i++)
            {
                if (i < 0 || i >= liczby.Length) continue;
                Console.WriteLine(liczby[i]);
            }
        }

        public Summator(int[] initialNumbers)
        {
            liczby = initialNumbers;
        }
    }
}