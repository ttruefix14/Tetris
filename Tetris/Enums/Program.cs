using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(5, 5, '#');

            square.Draw();

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if(!square.consoleMoves.ContainsKey(key)) {
                    break;
                }
                square.Move(square.consoleMoves[key]);
            }


            Console.ReadLine();
        }
    }
}
