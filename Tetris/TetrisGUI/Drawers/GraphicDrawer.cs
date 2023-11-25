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
        const int GRID_WIDTH = 2;
        const string PEN_COLOR = "Black";
        const string BACKGROUND_COLOR = "LightBlue";
        private string _brushColor;
        public string BrushColor {  get { return _brushColor; } set { _brushColor = value; } }
        public void ClearPoint(int x, int y)
        {
            GraphicsWindow.PenColor = BACKGROUND_COLOR;
            GraphicsWindow.DrawRectangle(ClearX(x), ClearY(y), BLOCK_SIZE + GRID_WIDTH, BLOCK_SIZE + GRID_WIDTH);
            GraphicsWindow.BrushColor = BACKGROUND_COLOR;
            GraphicsWindow.FillRectangle(ClearX(x), ClearY(y), BLOCK_SIZE + GRID_WIDTH, BLOCK_SIZE + GRID_WIDTH);
        }
        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.PenColor = PEN_COLOR;
            GraphicsWindow.BrushColor = BrushColor;
            GraphicsWindow.DrawRectangle(GetX(x), GetY(y), BLOCK_SIZE, BLOCK_SIZE);
            GraphicsWindow.FillRectangle(GetX(x), GetY(y), BLOCK_SIZE, BLOCK_SIZE);
        }
        public void GameOver()
        {
            GraphicsWindow.Clear();
            GraphicsWindow.DrawText(Field.Width * BLOCK_SIZE / 2, Field.Height * BLOCK_SIZE / 2, "GAME OVER");
        }
        public void InitField()
        {
            GraphicsWindow.KeyDown += GraphicController.KeyDown;
            GraphicsWindow.Width = Field.Width * BLOCK_SIZE + (Field.Width * GRID_WIDTH + GRID_WIDTH) * GRID_WIDTH;
            GraphicsWindow.Height = Field.Height * BLOCK_SIZE + (Field.Height * GRID_WIDTH + GRID_WIDTH) * GRID_WIDTH;

            GraphicsWindow.BackgroundColor = BACKGROUND_COLOR;
        }
        private static int GetX(int x)
        {
            return (GRID_WIDTH + x * GRID_WIDTH) * GRID_WIDTH + x * BLOCK_SIZE;
        }
        private static int ClearX(int x)
        {
            return ((GRID_WIDTH + x * GRID_WIDTH) * GRID_WIDTH + x * BLOCK_SIZE) - GRID_WIDTH / 2;
        }
        private static int GetY(int y)
        {
            return (GRID_WIDTH + y * GRID_WIDTH) * GRID_WIDTH + y * BLOCK_SIZE;
        }
        private static int ClearY(int y)
        {
            return ((GRID_WIDTH + y * GRID_WIDTH) * GRID_WIDTH + y * BLOCK_SIZE) - GRID_WIDTH / 2;
        }


    }
}
