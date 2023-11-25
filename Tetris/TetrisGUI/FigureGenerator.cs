using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGUI.Drawers;

namespace TetrisGUI
{
    public class FigureGenerator
    {
        public Random RandomGen { get { return _random; } }
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        private Random _random = new Random();
        private int _x;
        private int _y;

        private static string[] _colors = new string[]
        {
            "Red", "Orange", "Green", "Purple"
        };
        public static string[] Colors { get { return _colors; } }
        public string GetColor()
        {
            string color = Colors[RandomGen.Next(0, Colors.Length)];
            return color;
        }

        public FigureGenerator(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Figure GetRandomFigure()
        {
            FigureType figureType = (FigureType)RandomGen.Next(0, Enum.GetNames(typeof(FigureType)).Length);
            GraphicDrawer.BrushColor = GetColor();
            switch (figureType)
            {
                case FigureType.Square:
                    return new Square(X, Y);
                case FigureType.Stick:
                    return new Stick(X, Y); ;
                case FigureType.ShapeT:
                    return new ShapeT(X, Y);
                case FigureType.ShapeL:
                    return new ShapeL(X, Y);
                case FigureType.ShapeJ:
                    return new ShapeJ(X, Y);
                case FigureType.ShapeZ:
                    return new ShapeZ(X, Y);
                case FigureType.ShapeS:
                    return new ShapeS(X, Y);
                default:
                    throw new Exception("Не существующий тип фигуры");
            } 
        }
    }
}
