using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class FigureGenerator
    {
        public Random RandomGen { get { return _random; } }
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public char C { get { return _c; } set { _c = value; } }

        private Random _random = new Random();
        private int _x;
        private int _y;
        private char _c;

        public FigureGenerator(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }

        public Figure GetRandomFigure()
        {
            FigureType figureType = (FigureType)RandomGen.Next(0, Enum.GetNames(typeof(FigureType)).Length);
            switch(figureType)
            {
                case FigureType.Square:
                    return new Square(X, Y, C);
                case FigureType.Stick:
                    return new Stick(X, Y, C); ;
                case FigureType.ShapeT:
                    return new ShapeT(X, Y, C);
                default:
                    throw new Exception("Не существующий тип фигуры");
            } 
        }
    }
}
