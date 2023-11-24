using Microsoft.SmallBasic.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGUI.Controllers;

namespace TetrisGUI.Drawers
{
    class GraphicDrawer : IDrawer
    {
        const int BLOCK_SIZE = 10;
        const string PEN_COLOR = "Red";
        const string BACKGROUND_COLOR = "LightBlue";
        public void ClearPoint(int x, int y)
        {
            GraphicsWindow.PenColor = BACKGROUND_COLOR;
            GraphicsWindow.DrawRectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE);
        }

        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = PEN_COLOR;
            GraphicsWindow.DrawRectangle(x * BLOCK_SIZE, y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE);
        }

        public void GameOver()
        {
            GraphicsWindow.Clear();
            GraphicsWindow.DrawText(Field.Width * BLOCK_SIZE / 2, Field.Height * BLOCK_SIZE / 2, "GAME OVER");
        }

        public void InitField()
        {
            GraphicsWindow.KeyDown += GraphicController.KeyDown;
            GraphicsWindow.Width = Field.Width * BLOCK_SIZE;
            GraphicsWindow.Height = Field.Height * BLOCK_SIZE;

            GraphicsWindow.BackgroundColor = BACKGROUND_COLOR;
        }
    }
}
