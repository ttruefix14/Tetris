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

        public static bool[][] Heap { get { return _heap; } }

        static Field()
        {
            _heap = new bool[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
            Console.SetWindowSize(Width + 1, Height);
            Console.SetBufferSize(Width + 2, Height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.CursorVisible = false;
        }
        
        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }
        public static bool AddFigure(Figure figure)
        {
            foreach(var p in figure.Points)
            {
                if (_heap[p.Y][p.X])
                    return false;
                _heap[p.Y][p.X] = true;
            }
            return true;
        }

        public static bool FigureFall(ref Figure figure, FigureGenerator generator)
        {
            bool figureFell = figure.TryMove(Direction.Down);
            if(!figureFell)
            {
                bool figureAdded = AddFigure(figure);
                if (!figureAdded)
                {
                    GameOver();
                    return true;
                }
                bool rowCleared = ClearFullRows();
                if (rowCleared)
                    Redraw();
                figure = generator.GetRandomFigure();
            }
            return false;
        }

        private static void GameOver()
        {
            //Console.Clear();
            DrawerProvider.Drawer.GameOver();
        }

        private static void Redraw()
        {
            for(int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_heap[y][x])
                    {
                        DrawerProvider.Drawer.DrawPoint(x, y);
                    }
                    else
                    {
                        DrawerProvider.Drawer.ClearPoint(x, y);
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
