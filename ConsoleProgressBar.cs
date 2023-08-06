using ConsoleAddonLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddonLibrary
{
    public class ConsoleProgressBar
    {
        public ConsoleProgressBar(int endValue)
        {
            _endValue = endValue;
        }

        public int BarLenght = 30;

        private int _verticalCursorPos;
        private bool _isShown = false;

        private string _borderUp = string.Empty;
        private string _borderDown = string.Empty;

        private int _endValue;
        private int _value = 0;
        public int Value
        {
            get { return _value; }
            set { 
                _value = value;
                CheckIsFinished();
                }
        }

        public void Show()
        {
            UpdateBorders();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(_borderUp);
            _verticalCursorPos = Console.CursorTop;
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            string bar = string.Empty;
            for (int i = 0; i < BarLenght; i++)
            {
                bar += "#";
            }

            Console.Write(bar);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" ║ ");
            Console.WriteLine(_borderDown);
            _isShown = true;
        }

        private void UpdateBar()
        {
            if (_isShown)
            {
                Console.CursorTop = _verticalCursorPos;
                Console.CursorLeft = 2;

                int lenght = GetFinishedElements(_value, _endValue);
                string bar = string.Empty;
                for (int i = 0; i < lenght; i++)
                {
                    bar += "█";
                }
                Console.Write(bar);
            }
        }


        private void UpdateBorders()
        {
            _borderUp = string.Empty;
            _borderUp += "╔";
            for (int i = 0; i < BarLenght + 2; i++)
            {
                _borderUp += "═";
            }
            _borderUp += "╗";

            _borderDown = string.Empty;
            _borderDown += "╚";
            for (int i = 0; i < BarLenght + 2; i++)
            {
                _borderDown += "═";
            }
            _borderDown += "╝";
        }

        private void CheckIsFinished()
        {
            if (_value >= _endValue)
            {
                ConsoleLogs.SystemLog("Task Copleted");
            }
            else
            {
                UpdateBar();
            }
        }

        public int GetFinishedElements(int completedTasks, int totalTasks)
        {
            // Определяем процент выполненных задач.
            int percentComplete = (int)Math.Round(((double)completedTasks / (double)totalTasks) * 100.0);

            // Вычисляем количество элементов, которые должны быть выведены.
            int numElements = (int)Math.Round(((double)percentComplete / 100.0) * BarLenght);

            return numElements;
        }
    }
}
