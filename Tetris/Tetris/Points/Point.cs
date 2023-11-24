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
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point() { }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
        }

        public void Clear()
        {
            DrawerProvider.Drawer.ClearPoint(X, Y);
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
