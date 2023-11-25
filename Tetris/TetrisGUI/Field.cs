using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TetrisGUI.Drawers;

namespace TetrisGUI
{
    static class Field
    {
        public static int Width
        {
            get { return _width; }
            //set 
            //{
            //    if(!(value <= Console.LargestWindowWidth && value > 10))
            //    {
            //        return;
            //    }
            //    _width = value;
            //    Console.SetWindowSize(Field._width, Field._height);
            //    Console.SetBufferSize(Field._width, Field._height);
            //}
        }
        public static int Height
        {
            get { return _height; }
            //set
            //{
            //    if(!(value <= Console.LargestWindowHeight && value > 10))
            //    {
            //        return;
            //    }
            //    _height = value;
            //    Console.SetWindowSize(Field._width, Field._height);
            //    Console.SetBufferSize(Field._width, Field._height);
            //}
        }

        private static int _width = 10;
        private static int _height = 22;

        private static string[][] _heap;

        public static string[][] Heap { get { return _heap; } }

        static Field()
        {
            _heap = new string[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new string[Width];
            }
            DrawerProvider.Drawer.InitField();
        }
        
        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X] != null;
        }
        public static bool AddFigure(Figure figure)
        {
            foreach(var p in figure.Points)
            {
                if (_heap[p.Y][p.X] != null)
                    return false;
                _heap[p.Y][p.X] = DrawerProvider.Drawer.BrushColor;
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
            DrawerProvider.Drawer.GameOver();
        }

        private static void Redraw()
        {
            for(int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_heap[y][x] != null)
                    {
                        DrawerProvider.Drawer.BrushColor = _heap[y][x];
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
            return _heap[row].All(p => p != null);
        }

        private static void DeleteRow(int line)
        {
            for(int y = line; y >= 0; y--)
            {
                for (int x = 0; x < _heap[y].Length; x++)
                {
                    if (y == 0)
                    {
                        _heap[y][x] = null;
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
