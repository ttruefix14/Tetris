using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class ShapeL : Figure
    {
        private Rotation _rotation = Rotation.None;
        public Rotation Rotation { get { return _rotation; } set { _rotation = value; } }
        public ShapeL(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x + 1, y);
            Points[2] = new Point(x + 2, y);
            Points[3] = new Point(x, y + 1);
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
                    RotateNone(pList);
                    Rotation += 1;
                    break;
                case Rotation.One:
                    RotateOne(pList);
                    Rotation += 1;
                    break;
                case Rotation.Two:
                    RotateTwo(pList);
                    Rotation += 1;
                    break;
                case Rotation.Three:
                    RotateThree(pList);
                    Rotation = Rotation.None;
                    break;
                default:
                    break;
            }
        }

        private void RotateNone(Point[] pList)
        {
            pList[0].X += 1;

            pList[1].Y += 1;

            pList[2].X -= 1;
            pList[2].Y += 2;

            pList[3].Y -= 1;
        }
        private void RotateOne(Point[] pList)
        {
            pList[0].X += 1;
            pList[0].Y += 1;

            pList[2].X -= 1;
            pList[2].Y -= 1;

            pList[3].X += 2;
        }
        private void RotateTwo(Point[] pList)
        {
            pList[0].X -= 2;
            pList[0].Y += 1;

            pList[1].X -= 1;

            pList[2].Y -= 1;

            pList[3].X -= 1;
            pList[3].Y += 2;
        }
        private void RotateThree(Point[] pList)
        {
            pList[0].Y -= 2;

            pList[1].X += 1;
            pList[1].Y -= 1;

            pList[2].X += 2;

            pList[3].X -= 1;
            pList[3].Y -= 1;
        }

    }
}
