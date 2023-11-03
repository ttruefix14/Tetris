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
            points[0] = new Point(x, y, c);
            points[1] = new Point(x + 1, y, c);
            points[2] = new Point(x, y + 1, c);
            points[3] = new Point(x + 1, y +  1, c);
        }

        public void Draw()
        {
            foreach(Point p in points)
            {
                p.Draw();
            }

        }
    }
}
