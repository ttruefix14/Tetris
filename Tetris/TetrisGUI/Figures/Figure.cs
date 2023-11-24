using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TetrisGUI
{
    public abstract class Figure
    {
        private const int LENGTH = 4;

        private Point[] _figureClone = new Point[LENGTH]
        {
            new Point(), new Point(), new Point(), new Point()
        };

        public Point[] Points
        { 
            get { return _points; } 
            set { _points = value; } 
        }
        private Point[] _points = new Point[LENGTH];

        public void Draw()
        {
            foreach(Point p in Points)
            {
                p.Draw();
            }
        }

        public void Clear()
        {
            foreach(Point p in Points)
            {
                p.Clear();
            }
        }

        public bool TryMove(Direction dir)
        {
            var clone = Clone();
            Move(clone, dir);
            if(!VerifyPosition(clone))
            {
                return false;
            }
            else
            {
                Clear();
                ReplaceWithClone();
                Draw();
                //Thread.Sleep(1);
            }
            return true;
        }

        protected void ReplaceWithClone()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                Points[i].X = _figureClone[i].X;
                Points[i].Y = _figureClone[i].Y;
            }
        }

        private void Move(Point[] pList, Direction dir)
        {
            foreach(Point p in pList)
            {
                p.Move(dir);
            }
        }

        protected Point[] Clone()
        {
            for(int i = 0; i < LENGTH; i++)
            {
                _figureClone[i].X = Points[i].X;
                _figureClone[i].Y = Points[i].Y;
            }
            return _figureClone;
        }

        protected bool VerifyPosition(Point[] pList)
        {
            foreach(Point p in pList)
            {
                if(p.Y >= Field.Height || p.X < 0 || p.X >= Field.Width || Field.CheckStrike(p))
                {
                    return false;
                }
            }
            return true;
        }

        public abstract void Rotate(Point[] pList);
        public abstract void TryRotate();

        private static readonly Dictionary<ConsoleKey, Direction> _consoleMoves = new Dictionary<ConsoleKey, Direction>()
        {
            { ConsoleKey.LeftArrow, Direction.Left },
            { ConsoleKey.RightArrow, Direction.Right },
            { ConsoleKey.DownArrow, Direction.Down }
        };
        public static bool SupportConsoleMove(ConsoleKey key)
        {
            return _consoleMoves.ContainsKey(key);
        }
        public static Direction GetDirection(ConsoleKey key)
        {
            return _consoleMoves[key];
        }
    }
}
