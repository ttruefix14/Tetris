using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TetrisGUI.Drawers;

namespace TetrisGUI
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new GraphicDrawer();

        public static IDrawer Drawer { get {  return _drawer; } }
    }
}
