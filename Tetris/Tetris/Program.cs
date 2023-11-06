using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);
            Console.CursorVisible = false;

            Field.Width = 20;
            Field.Height = 85;

            FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0, '*');

            Figure figure = generator.GetRandomFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if(key.Key == ConsoleKey.Escape)
                        break;
                    HandleKey(figure, key);
                }
                FigureFall(ref figure, generator);
            }
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            if(Field.SupportConsoleMove(key.Key))
            {
                figure.TryMove(Field.GetDirection(key.Key));
            }
            else if(key.Key == ConsoleKey.Spacebar)
            {
                figure.TryRotate();
            }
        }

        static void FigureFall(ref Figure figure, FigureGenerator generator)
        {
            Thread.Sleep(100);
            if (!figure.TryMove(Direction.Down))
            {
                figure = generator.GetRandomFigure();
            }
        }
    }
}
