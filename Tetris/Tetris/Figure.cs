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
        public static int Length
        {
            get { return _length; }
        }
        private static readonly int _length = 4;

        public Point[] Points
        { 
            get { return _points; } 
            set { _points = value; } 
        }
        private Point[] _points = new Point[Length];

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
                Points = clone;
                Draw();
                Thread.Sleep(1);
            }
            return true;
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
            var newPoints = new Point[Length];
            for(int i = 0; i < Length; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
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
