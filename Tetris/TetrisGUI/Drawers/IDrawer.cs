using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI
{
    interface IDrawer
    {
        string BrushColor { get; set; }
        void InitField();
        void DrawPoint(int x, int y);
        void ClearPoint(int x, int y);
        void GameOver();
    }
}
