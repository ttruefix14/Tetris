using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI.Controllers
{
    interface IController
    {
        bool IsKeyAvailable();
        HandleKeyResult HandleKey(Figure figure);

    }
}
