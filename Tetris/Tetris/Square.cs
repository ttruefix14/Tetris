using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Square
    {
        Point[] points = new Point[4];
        
        public Square(int x, int y,  char c) 
        {
            points[0] = new Point(x, x, c);
            points[1] = new Point(x, y, c);
            points[2] = new Point(y, x, c);
            points[3] = new Point(y, y, c);
        }

        public void Draw()
        {
            foreach(Point p in points)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(p.c);
            }

        }
    }
}
