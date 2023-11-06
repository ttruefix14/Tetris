using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class FigureGenerator
    {
        private Random _random = new Random();
        private int _x;
        private int _y;
        private char _c;
        public FigureGenerator(int x, int y, char c)
        {
            _x = x;
            _y = y;
            _c = c;
        }
        public Figure GetRandomFigure()
        {
            FigureType figureType = (FigureType)_random.Next(0, Enum.GetNames(typeof(FigureType)).Length);

            switch (figureType)
            {
                case FigureType.Square:
                    return new Square(_x, _y, _c);
                case FigureType.Stick:
                    return new Stick(_x, _y, _c); ;
                default:
                    throw new Exception("Не существующий тип фигуры");
            } 
        }
    }
}
