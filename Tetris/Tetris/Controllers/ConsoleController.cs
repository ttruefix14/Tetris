using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controllers
{
    class ConsoleController : IController
    {
        public HandleKeyResult HandleKey(Figure figure)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return HandleKeyResult.Exit;
            }
            else if (Figure.SupportConsoleMove(key.Key))
            {
                figure.TryMove(Figure.GetDirection(key.Key));
                return HandleKeyResult.FigureMoved;
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                figure.TryRotate();
                return HandleKeyResult.FigureRotated;
            }
            else
            {
                return HandleKeyResult.WrongKey;
            }
        }

        public bool IsKeyAvailable()
        {
            return Console.KeyAvailable;
        }
    }
}
