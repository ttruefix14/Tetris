using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int value = random.Next(0, 5);
            Console.WriteLine(value);

            Console.ReadLine();
        }
    }
}
