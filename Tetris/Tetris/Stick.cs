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
        public Stick(int x, int y, char c)
        {
            points[0] = new Point(x, y, c);
            points[1] = new Point(x, y + 1, c);
            points[2] = new Point(x, y + 2, c);
            points[3] = new Point(x, y + 3, c);
        }
        public override void Rotate()
        {
            Clear();
            if (points[0].x == points[1].x)
            {
                RotateHorizontal();
            } 
            else
            {
                RotateVertical();
            }
            //int dx, dy;
            //if (rotation == Rotation.None || rotation == Rotation.Two) 
            //{
            //    dx = 1;
            //    dy = -1;
            //}
            //else
            //{
            //    dx = -1;
            //    dy = 1;
            //}
            //for(int i = 0; i < points.Length; i++)
            //{
            //    points[i].Rotate(i * dx, i * dy);
            //}
            //rotation = (rotation == Rotation.Three) ? Rotation.None : rotation + 1;
            Draw();
        }

        private void RotateVertical()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = points[0].x;
                points[i].y = points[0].y + i;
            }
        }

        private void RotateHorizontal()
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }
    }
}
