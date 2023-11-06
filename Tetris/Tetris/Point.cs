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
        public int x;
        public int y;
        public char c;

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    x -= 1;
                    break;
                case Direction.Right:
                    x += 1;
                    break;
                case Direction.Down:
                    y += 1;
                    break;
            }
        }
        public void Rotate(int xx, int yy)
        {
            x += xx;
            y += yy;
        }
        public Point(int a, int b, char sym) 
        { 
            x = a;
            y = b;
            c = sym;
        }
        public Point() { }

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.c = p.c;
        }
    }
}
