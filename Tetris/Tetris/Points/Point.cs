using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }
        public Point() { }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }

        public void Move(Direction dir)
        {
            switch(dir)
            {
                case Direction.Left:
                    X -= 1;
                    break;
                case Direction.Right:
                    X += 1;
                    break;
                case Direction.Down:
                    Y += 1;
                    break;
            }
        }

        public void Rotate(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

    }
}
