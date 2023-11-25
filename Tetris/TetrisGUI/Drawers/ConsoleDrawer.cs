using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI
{
    class ConsoleDrawer : IDrawer
    {
        public static readonly char _defaultSymbol = '#';
        public char DefaultSymbol { get { return _defaultSymbol; } }

        public string BrushColor { get; set; }

        public void InitField()
        {
            Console.SetWindowSize(Field.Width + 1, Field.Height);
            Console.SetBufferSize(Field.Width + 2, Field.Height);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.CursorVisible = false;
        }
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

        public void GameOver()
        {
            string[] message = new string[] { "I N", "L O V I N G", "M E M O R Y", "O F", "J O N A S", "N E U B A U E R" };
            int cursorTop = (Field.Height - (message.Length * 2 - 1)) / 2;
            for (int i = 0; i < message.Length; i++)
            {
                int cursorLeft = (Field.Width - message[i].Length) / 2;
                if (i == 0)
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                else
                    Console.SetCursorPosition(cursorLeft, cursorTop + i);
                Console.Write(message[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
