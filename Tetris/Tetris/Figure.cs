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
        public Point[] points = new Point[4];

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

        public void Move(Direction dir)
        {
            Thread.Sleep(100);
            Clear();
            foreach(Point p in points)
            {
                p.Move(dir);
            }
            Draw();
        }

        public abstract void Rotate();
         
        public Dictionary<ConsoleKey, Direction> consoleMoves = new Dictionary<ConsoleKey, Direction>()
        {
            { ConsoleKey.LeftArrow, Direction.Left },
            { ConsoleKey.RightArrow, Direction.Right },
            { ConsoleKey.DownArrow, Direction.Down }
        };


    }
}
