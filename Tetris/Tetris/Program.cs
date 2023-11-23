using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Timers;

namespace Tetris
{
    internal class Program
    {
        static System.Timers.Timer timer;
        const int TIMER_INTERVAL = 500;
        static private object _lockObject = new object();
        static private bool _gameOver = false;

        static Figure figure;
        static FigureGenerator generator;
        static void Main(string[] args)
        {
            generator = new FigureGenerator(Field.Width / 2, 0, DrawerProvider.Drawer.DefaultSymbol);
            figure = generator.GetRandomFigure();
            SetTimer();

            while (true)
            {
                if (_gameOver)
                {
                    break;
                }
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    if (key.Key == ConsoleKey.Escape)
                        break;
                    HandleKey(figure, key);
                    Monitor.Exit(_lockObject);
                }
            }
            Console.ReadKey();
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            bool gameOver = Field.FigureFall(ref figure, generator);
            if (gameOver)
            {
                _gameOver = true;
                timer = (System.Timers.Timer)sender;
                timer.Stop();
            }
            Monitor.Exit(_lockObject);
        }

        private static void HandleKey(Figure figure, ConsoleKeyInfo key)
        {
            if (Figure.SupportConsoleMove(key.Key))
            {
                figure.TryMove(Figure.GetDirection(key.Key));
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                figure.TryRotate();
            }
        }
    }
}
