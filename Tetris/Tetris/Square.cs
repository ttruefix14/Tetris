using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Square
    {
        Point[][] points = new Point[2][] {new Point[2], new Point[2] };
        
        public Square(Point topLeftPoint) 
        {
            points[0][0] = topLeftPoint;
            points[0][1] = new Point(topLeftPoint.x, topLeftPoint.y + 1, topLeftPoint.c);
            points[1][0] = new Point(topLeftPoint.x + 1, topLeftPoint.y, topLeftPoint.c);
            points[1][1] = new Point(topLeftPoint.x + 1, topLeftPoint.y + 1, topLeftPoint.c);
        }

        public void Draw()
        {
            foreach(Point[] row in points)
            {
                foreach(Point p in row)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(p.c);
                }
            }

        }
    }
}
