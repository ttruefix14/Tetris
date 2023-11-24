using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controllers
{
    static class ControllerProvider
    {
        private static IController _controller = new ConsoleController();

        public static IController Controller { get { return _controller; } }
    }
}
