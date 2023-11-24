using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.Controllers
{
    class GraphicController : IController
    {
        private static bool _isKeyAvailable = false;
        public bool IsKeyAvailable()
        {
            return _isKeyAvailable;
        }

        internal static void KeyDown()
        {
            _isKeyAvailable = true;
        }

        public HandleKeyResult HandleKey(Figure figure)
        {
            _isKeyAvailable = false;
            switch (GraphicsWindow.LastKey.ToString())
            {
                case "Escape":
                    return HandleKeyResult.Exit;
                case "Space":
                    figure.TryRotate();
                    return HandleKeyResult.FigureRotated;
                case "Left":
                    figure.TryMove(Direction.Left);
                    return HandleKeyResult.FigureMoved;
                case "Right":
                    figure.TryMove(Direction.Right);
                    return HandleKeyResult.FigureMoved;
                case "Down":
                    figure.TryMove(Direction.Down);
                    return HandleKeyResult.FigureMoved;
                default:
                    return HandleKeyResult.WrongKey;
            }
        }
    }
}
