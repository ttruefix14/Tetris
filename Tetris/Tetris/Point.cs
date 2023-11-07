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

        public Point(int a, int b, char sym)
        {
            X = a;
            Y = b;
            C = sym;
        }
        public Point() { }

        public Point(Point p)
        {
            this.X = p.X;
            this.Y = p.Y;
            this.C = p.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public void Move(Direction dir)
        {
            switch (dir)
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

        public void Rotate(int xx, int yy)
        {
            X += xx;
            Y += yy;
        }

    }
}
