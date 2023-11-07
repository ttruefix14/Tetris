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

            Field.Width = 40;
            Field.Height = 30;

            FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0, '*');

            Figure figure = generator.GetRandomFigure();

            while(true)
            {
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if(key.Key == ConsoleKey.Escape)
                        break;
                    HandleKey(figure, key);
                }
                Field.FigureFall(ref figure, generator);
            }
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            if(Figure.SupportConsoleMove(key.Key))
            {
                figure.TryMove(Figure.GetDirection(key.Key));
            }
            else if(key.Key == ConsoleKey.Spacebar)
            {
                figure.TryRotate();
            }
        }

    }
}
