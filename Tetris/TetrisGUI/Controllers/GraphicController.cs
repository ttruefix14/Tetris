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
        public bool IsKeyAvailable()
        {
            bool isKeyAvailable = GraphicsWindow.LastKey != "None";
            
            GraphicsWindow.DrawText(1, 1, GraphicsWindow.LastKey);
            return isKeyAvailable;
        }

        public HandleKeyResult HandleKey(Figure figure)
        {
            return HandleKeyResult.WrongKey;
        }
    }
}
