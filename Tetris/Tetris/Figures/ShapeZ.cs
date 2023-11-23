using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class ShapeZ : Figure
    {
        private Rotation _rotation = Rotation.None;
        public Rotation Rotation { get { return _rotation; } set { _rotation = value; } }
        public ShapeZ(int x, int y, char c)
        {
            Points[0] = new Point(x, y, c);
            Points[1] = new Point(x + 1, y, c);
            Points[2] = new Point(x + 1, y + 1, c);
            Points[3] = new Point(x + 2, y + 1, c);
            Draw();
        }

        public override void TryRotate()
        {
            var clone = Clone();
            Rotate(clone);
            if (!VerifyPosition(clone))
            {
                return;
            }
            else
            {
                Clear();
                ReplaceWithClone();
                Draw();
                //Thread.Sleep(100);
            }
        }

        public override void Rotate(Point[] pList)
        {
            switch (Rotation)
            {
                case Rotation.None:
                    RotateHorizontal(pList);
                    Rotation += 1;
                    break;
                case Rotation.One:
                    RotateVertical(pList);
                    Rotation += 1;
                    break;
                case Rotation.Two:
                    RotateHorizontal(pList);
                    Rotation += 1;
                    break;
                case Rotation.Three:
                    RotateVertical(pList);
                    Rotation = Rotation.None;
                    break;
                default:
                    break;
            }
        }

        private void RotateHorizontal(Point[] pList)
        {
            pList[0].X += 1;

            pList[1].Y += 1;

            pList[2].X -= 1;

            pList[3].X -= 2;
            pList[3].Y += 1;
        }        
        private void RotateVertical(Point[] pList)
        {
            pList[0].X -= 1;

            pList[1].Y -= 1;

            pList[2].X += 1;

            pList[3].X += 2;
            pList[3].Y -= 1;
        }        
    }
}
