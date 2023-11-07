using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public static int Width
        {
            get { return _width; }
            set 
            {
                if(!(value <= Console.LargestWindowWidth && value > 10))
                {
                    return;
                }
                _width = value;
                Console.SetWindowSize(Field._width, Field._height);
                Console.SetBufferSize(Field._width, Field._height);
            }
        }
        public static int Height
        {
            get { return _height; }
            set
            {
                if(!(value <= Console.LargestWindowHeight && value > 10))
                {
                    return;
                }
                _height = value;
                Console.SetWindowSize(Field._width, Field._height);
                Console.SetBufferSize(Field._width, Field._height);
            }
        }

        private static int _width = 40;
        private static int _height = 30;

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }
        
        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
        public static void AddFigure(Figure figure)
        {
            foreach(var p in figure.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static void FigureFall(ref Figure figure, FigureGenerator generator)
        {
            Thread.Sleep(100);
            if (!figure.TryMove(Direction.Down))
            {
                AddFigure(figure);
                figure = generator.GetRandomFigure();
            }
        }
    }
}
