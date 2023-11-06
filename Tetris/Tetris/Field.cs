using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public const int WIDTH = 40;
        public const int HEIGTH = 30;
        public const int LENGTH = 4;

        public static Dictionary<ConsoleKey, Direction> consoleMoves = new Dictionary<ConsoleKey, Direction>()
        {
            { ConsoleKey.LeftArrow, Direction.Left },
            { ConsoleKey.RightArrow, Direction.Right },
            { ConsoleKey.DownArrow, Direction.Down }
        };
    }
}
