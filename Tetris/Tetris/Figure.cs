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
        protected int min_y = 0;
        protected int max_y = 30 - 1;
        protected int min_x = 0;
        protected int max_x = 40 - 1;

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
            if(TouchBorder(dir))
            {
                return;
            }
            Clear();
            foreach(Point p in points)
            {
                p.Move(dir);
            }
            Draw();
            Thread.Sleep(100);
        }

        private bool TouchBorder(Direction dir)
        {
            foreach(Point p in points)
            {
                if(dir == Direction.Down && p.y >= max_y)
                {
                    return true;
                }
                else if(dir == Direction.Left && p.x <= min_x || dir == Direction.Right && p.x >= max_x)
                {
                    return true;
                }
            }
            return false;
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
