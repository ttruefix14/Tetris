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

            Stick stick = new Stick(5, 5, '#');

            stick.Draw();

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (stick.consoleMoves.ContainsKey(key))
                {
                    stick.Move(stick.consoleMoves[key]);
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    stick.Rotate();
                }
                else { break; }
            }


            Console.ReadLine();
        }
    }
}
