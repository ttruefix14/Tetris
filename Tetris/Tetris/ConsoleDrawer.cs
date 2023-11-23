using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ConsoleDrawer : IDrawer
    {
        public static readonly char _defaultSymbol = '*';
        public char DefaultSymbol { get { return _defaultSymbol;  } }

        public void DrawPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(DefaultSymbol);
            Console.SetCursorPosition(0, 0);
        }

        public void ClearPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}
