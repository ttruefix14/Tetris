using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new ConsoleDrawer2();

        public static IDrawer Drawer { get {  return _drawer; } }
    }
}
