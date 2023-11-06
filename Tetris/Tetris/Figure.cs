using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Figure
    {
        const int LENGTH = 4;
        protected int min_y = 1;
        protected int max_y = 30 - 2;
        protected int min_x = 1;
        protected int max_x = 40 - 2;

        public Point[] points = new Point[LENGTH];

        protected Rotation rotation = Rotation.None;

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        public void Clear()
        {
            foreach (Point p in points)
            {
                p.Clear();
            }
        }
        public void TryMove(Direction dir)
        {
            var clone = Clone();
            Move(clone, dir);
            if(IsOutBorder(clone))
            {
                return;
            }
            else
            {
                Clear();
                points = clone;
                Draw();
                Thread.Sleep(100);
            }
        }
        private void Move(Point[] pList, Direction dir)
        {
            foreach(Point p in pList)
            {
                p.Move(dir);
            }
        }

        //public void Move(Direction dir)
        //{
        //    Clear();
        //    foreach(Point p in points)
        //    {
        //        p.Move(dir);
        //    }
        //    Draw();
        //    Thread.Sleep(100);
        //}

        protected Point[] Clone()
        {
            var newPoints = new Point[LENGTH];
            for(int i = 0; i < LENGTH; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        protected bool IsOutBorder(Point[] pList)
        {
            foreach(Point p in pList)
            {
                if(p.y > max_y || p.x < min_x || p.x > max_x)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void Rotate(Point[] pList);

        public abstract void TryRotate();

        public Dictionary<ConsoleKey, Direction> consoleMoves = new Dictionary<ConsoleKey, Direction>()
        {
            { ConsoleKey.LeftArrow, Direction.Left },
            { ConsoleKey.RightArrow, Direction.Right },
            { ConsoleKey.DownArrow, Direction.Down }
        };


    }
}
