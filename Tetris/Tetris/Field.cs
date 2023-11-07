using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public static int Width
        {
            get { return _width; }
            set 
            {
                if(!(value <= Console.LargestWindowWidth && value > 10))
                {
                    return;
                }
                _width = value;
                Console.SetWindowSize(Field._width, Field._height);
                Console.SetBufferSize(Field._width, Field._height);
            }
        }
        public static int Height
        {
            get { return _height; }
            set
            {
                if(!(value <= Console.LargestWindowHeight && value > 10))
                {
                    return;
                }
                _height = value;
                Console.SetWindowSize(Field._width, Field._height);
                Console.SetBufferSize(Field._width, Field._height);
            }
        }

        private static int _width = 40;
        private static int _height = 30;
    }
}
