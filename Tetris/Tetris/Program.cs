using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Draw(2, 3, '*');
            Draw(4, 5, '#');

            Console.ReadLine();
        }

        static void Draw(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(c);
        }
    }
}
