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

        private static int _width = 20;
        private static int _height = 30;

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.CursorVisible = false;
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
            bool result = figure.TryMove(Direction.Down);
            if(!result)
            {
                AddFigure(figure);
                bool rowCleared = ClearFullRows();
                if (rowCleared)
                    Redraw(figure.Points[0].C);
                figure = generator.GetRandomFigure();
            }
        }

        private static void Redraw(char c)
        {
            for(int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    if (_heap[y][x])
                    {
                        Drawer.DrawPoint(x, y, c);
                    }
                    else
                    {
                        Drawer.ClearPoint(x, y);
                    }
                }
            }
        }

        public static bool ClearFullRows()
        {
            bool rowCleared = false;
            for(int y = _heap.Length - 1; y >= 0; y--)
            {
                bool rowIsFull = RowIsFull(y);
                while(rowIsFull)
                {
                    DeleteRow(y);
                    rowIsFull = RowIsFull(y);
                    rowCleared = true;
                }
            }
            return rowCleared;
        }

        private static bool RowIsFull(int row)
        {
            return _heap[row].All(p => p == true);
        }

        private static void DeleteRow(int line)
        {
            for(int y = line; y >= 0; y--)
            {
                for (int x = 0; x < _heap[y].Length; x++)
                {
                    if (y == 0)
                    {
                        _heap[y][x] = false;
                    }
                    else
                    {
                        _heap[y][x] = _heap[y - 1][x];
                    }
                }
            }
        }
    }
}
