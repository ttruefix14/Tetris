using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI
{
    public class Square : Figure
    {
        public Square(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x + 1, y);
            Points[2] = new Point(x, y + 1);
            Points[3] = new Point(x + 1, y + 1);
            Draw();
        }

        public override void Rotate(Point[] pList) { }

        public override void TryRotate() { }
    }
}
