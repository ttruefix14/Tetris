using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            Console.CursorVisible = false;

            FigureGenerator generator = new FigureGenerator(20, 0, '*');

            Figure figure = generator.GetRandomFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    HandleKey(figure, key);
                }
            }
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            if (figure.consoleMoves.ContainsKey(key.Key))
            {
                figure.TryMove(figure.consoleMoves[key.Key]);
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                figure.TryRotate();
            }
            else 
            { 

            }
        }
        //static void FigureFall(out Figure figure, FigureGenerator generator)
        //{
        //    figure = generator.GetRandomFigure();
        //    figure.Draw();

        //    for (int i = 0; i < 15; i++)
        //    {
        //        figure.Move(Direction.Down);
        //    }
        //}
    }
}
