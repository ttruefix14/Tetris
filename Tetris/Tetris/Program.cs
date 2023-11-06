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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');

            Figure figure = null;

            while (true)
            {
                FigureFall(figure, generator);

                figure.Draw();
            }

            //Figure figure = Generator.GetRandomFigure();
            //figure.Draw();

            //while (true)
            //{
            //    ConsoleKey key = Console.ReadKey().Key;
            //    if (figure.consoleMoves.ContainsKey(key))
            //    {
            //        figure.Move(figure.consoleMoves[key]);
            //    }
            //    else if (key == ConsoleKey.Spacebar)
            //    {
            //        figure.Rotate();
            //    }
            //    else { break; }
            //}


            Console.ReadLine();
        }
        static void FigureFall(Figure figure, FigureGenerator generator)
        {
            figure = generator.GetRandomFigure();
            figure.Draw();

            for (int j = 0; j < 15; j++)
            {
                figure.Move(Direction.Down);
            }
        }
    }
}
