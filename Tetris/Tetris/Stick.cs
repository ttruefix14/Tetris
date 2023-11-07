using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tetris
{
    public class Stick : Figure
    {
        public Stick(int x, int y, char c)
        {
            Points[0] = new Point(x, y, c);
            Points[1] = new Point(x, y + 1, c);
            Points[2] = new Point(x, y + 2, c);
            Points[3] = new Point(x, y + 3, c);
            Draw();
        }

        public override void TryRotate()
        {
            var clone = Clone();
            Rotate(clone);
            if(IsOutBorder(clone))
            {
                return;
            }
            else
            {
                Clear();
                Points = clone;
                Draw();
                Thread.Sleep(100);
            }
        }

        public override void Rotate(Point[] pList)
        {
            if(pList[0].X == pList[1].X)
            {
                RotateHorizontal(pList);
            }
            else
            {
                RotateVertical(pList);
            }
        }

        private void RotateVertical(Point[] pList)
        {
            for(int i = 0; i < pList.Length; i++)
            {
                pList[i].X = pList[0].X;
                pList[i].Y = pList[0].Y + i;
            }
        }

        private void RotateHorizontal(Point[] pList)
        {
            for(int i = 0; i < pList.Length; i++)
            {
                pList[i].Y = pList[0].Y;
                pList[i].X = pList[0].X + i;
            }
        }
    }
}
