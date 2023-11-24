using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Timers;
using TetrisGUI.Controllers;


namespace TetrisGUI
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
            generator = new FigureGenerator(Field.Width / 2, 0);
            figure = generator.GetRandomFigure();
            SetTimer();
            while (true)
            {
                if (_gameOver)
                {
                    break;
                }
                if (ControllerProvider.Controller.IsKeyAvailable())
                {
                    Monitor.Enter(_lockObject);
                    HandleKeyResult handleKeyResult = ControllerProvider.Controller.HandleKey(figure);
                    if (handleKeyResult == HandleKeyResult.Exit)
                    {
                        break;
                    }
                    Monitor.Exit(_lockObject);
                }
            }
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
    }
}
