using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tetris
{
    public class Stick : Figure
    {
        int dx = -1;
        int dy = -1;
        public Stick(int x, int y, char c)
        {
            points[0] = new Point(x, y, c);
            points[1] = new Point(x, y + 1, c);
            points[2] = new Point(x, y + 2, c);
            points[3] = new Point(x, y + 3, c);
        }
        public override void Rotate()
        {
            int xx = 1;
            int yy = 1;

            yy *= dy;
            foreach(Point p in points)
            {
                p.Rotate(xx, yy);
                xx += dx;
                yy += dy;
            }
            dy *= -1;
        }
    }
}
