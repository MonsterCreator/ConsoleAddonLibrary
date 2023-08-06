namespace ConsoleAddonLibary
{
    public static class ConsoleLogs
    {
        public static ConsoleColor SystemColor { get; private set; }
        public static ConsoleColor ErrorColor { get; private set; }
        public static ConsoleColor InfoColor { get; private set; }

        public const ConsoleColor DefaultSystemColor = ConsoleColor.Yellow;
        public const ConsoleColor DefaultErrorColor = ConsoleColor.Red;
        public const ConsoleColor DefaultInfoColor = ConsoleColor.Green;

        static ConsoleLogs() { SetDefaultColors(); }

        //The methods are responsible for displaying messages with a certain color of their type:
        //SystemLog methods:
        /// <summary>
        /// Your text are used SystemColor.
        /// </summary>
        
        public static void SystemLog(string message)
        {
            PrintMessageWithColor(message, SystemColor);
        }

        /// <summary>
        /// All text are used SystemColor. Use this method for complex log messages
        /// </summary>
        /// <param name="messages">A method that outputs several messages to the console</param>
        
        public static void SystemLog(Action messages)
        {
            PrintMessageWithColor(messages, SystemColor);
        }

        //ErrorLogMethods:
        //InfoLogMethods:
        /// <summary>
        /// Your text are used ErrorColor.
        /// </summary>
        
        public static void ErrorLog(string message)
        {
            PrintMessageWithColor(message, ErrorColor);
        }

        /// <summary>
        /// All text are used ErrorColor. Use this method for complex log messages
        /// </summary>
        /// <param name="messages">A method that outputs several messages to the console</param>
        
        public static void ErrorLog(Action messages)
        {
            PrintMessageWithColor(messages, ErrorColor);
        }

        //InfoLogMethods:
        /// <summary>
        /// Your text are used InfoColor.
        /// </summary>
        
        public static void InfoLog(string message)
        {
            PrintMessageWithColor(message, InfoColor);
        }

        /// <summary>
        /// All text are used InfoColor. Use this method for complex log messages
        /// </summary>
        /// <param name="messages">A method that outputs several messages to the console</param>
        
        public static void InfoLog(Action messages)
        {
            PrintMessageWithColor(messages, InfoColor);
        }


        //Methods for text color management:

        public static void SetSystemColor(ConsoleColor color) { SystemColor = color; }
        public static void SetErrorColor(ConsoleColor color) { ErrorColor = color; }
        public static void SetInfoColor(ConsoleColor color) { InfoColor = color; }

        public static void SetDefaultColors()
        {
            SystemColor = DefaultSystemColor;
            ErrorColor = DefaultErrorColor;
            InfoColor = DefaultInfoColor;
        }

        public static void PrintMessageWithColor(string message, ConsoleColor consoleColor)
        {
            ConsoleColor lastConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = lastConsoleColor;
        }

        public static void PrintMessageWithColor(Action messages, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            messages.Invoke();
            Console.ResetColor();
        }


        public static void GradualPrinting(string message, PrintingSpeed speed)
        {
            int printspeed = GetSpeed(speed);

            foreach (var symbol in message)
            {
                Console.Write(symbol);
                if (symbol == ' ')
                {
                    Thread.Sleep(printspeed * 2);
                }
                else
                {
                    Thread.Sleep(printspeed);
                }
            }
            Console.WriteLine();
        }

        private static int GetSpeed(PrintingSpeed speed)
        {
            switch (speed)
            {
                case PrintingSpeed.low: return 200;
                case PrintingSpeed.normal: return 100;
                case PrintingSpeed.fast: return 60;
                case PrintingSpeed.veryFast: return 30;
            }
            return 0;
        }

        public static void PrintSelected(Action messages)
        {
            ConsoleColor BGLastColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            messages.Invoke();
            Console.BackgroundColor = BGLastColor;
        }
    }
}

public enum PrintingSpeed
{
    low,
    normal,
    fast,
    veryFast
}