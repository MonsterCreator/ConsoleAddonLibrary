using ConsoleAddonLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddonLibrary
{
    public class ConsoleMenu
    {
        private List<MenuElement> menuElements = new List<MenuElement>();

        public string MenuName { get; set; }

        private ConsoleColor _boxColor = ConsoleColor.Gray;
        private int _selectedElement = 0;
        private int _verticalCursorPos = 0;
        private bool _isShown = false;

        private bool CloseMenu = false;

        public void AddMenuElement(MenuElement element) { menuElements.Add(element); }

        public void RemoveMenuElement(int index) { menuElements.Remove(menuElements[index]); }

        public void ShowMenu(bool ShowExitButton = false)
        {
            if (ShowExitButton) { AddMenuElement(new MenuElement("Close menu", () => Exit())); }

            PrintMenu();
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        menuElements[_selectedElement].Method.Invoke();
                        if (!CloseMenu)
                        {
                            ConsoleLogs.SystemLog("Press any key for continue");
                            Console.ReadKey();
                            Console.Clear();
                            _isShown = false;
                            PrintMenu();
                        }
                        else Console.Clear();
                        break;
                    case ConsoleKey.S:
                        if (_selectedElement < menuElements.Count - 1)
                        {
                            _selectedElement++;
                            PrintMenu();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_selectedElement < menuElements.Count - 1)
                        {
                            _selectedElement++;
                            PrintMenu();
                        }
                        break;
                    case ConsoleKey.W:
                        if (_selectedElement > 0)
                        {
                            _selectedElement--;
                            PrintMenu();
                            
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (_selectedElement > 0)
                        {
                            _selectedElement--;
                            PrintMenu();
                        }
                        break;
                }

                if (CloseMenu)
                {
                    RemoveMenuElement(menuElements.Count - 1);
                    CloseMenu = false;
                    _isShown = false;
                    return;
                }
            }
        }

        private void PrintMenu()
        {
            Console.ForegroundColor = _boxColor;
            string line = "";
            for (int i = 0; i < FindMaxLenght() + 4; i++)
            {
                line += "█";
            }
            

            if (!_isShown)
            {
                Console.WriteLine(line);
                if (MenuName != null)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    PrintLine(MenuName);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(line);
                    _verticalCursorPos = Console.CursorTop;
                }
                _isShown = true;
            }

            Console.CursorTop = _verticalCursorPos;
            if (menuElements != null)
            {
                for (int i = 0; i < menuElements.Count; i++)
                {
                    if (i == _selectedElement)
                    {
                        ConsoleLogs.PrintSelected(() =>
                        {
                            PrintLine(menuElements[i].ElementName);
                        });
                    }
                    else
                    {
                        PrintLine(menuElements[i].ElementName);
                    }
                }
                Console.WriteLine(line);
            }
        }

        private void PrintLine(string elmentName)
        {
            int maxLenght = FindMaxLenght();
            Console.Write("█ ");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write(elmentName);
            Console.ForegroundColor = _boxColor;
            string next = "";
            for (int i = 0; i < maxLenght - elmentName.Length; i++)
            {
                next += " ";
            }
            next += " █";
            Console.Write(next);
            Console.WriteLine();
        }

        private int FindMaxLenght()
        {
            int maxLenght = 0;
            foreach (MenuElement element in menuElements)
            {
                if (element.ElementName.Length > maxLenght)
                {
                    maxLenght = element.ElementName.Length;
                }
            }
            return maxLenght;
        }

        private void Exit()
        {
            CloseMenu = true;
        }
    }

    public class MenuElement
    {
        
        public MenuElement(string elementName, Action method)
        {
            if (string.IsNullOrEmpty(elementName))
            {
                throw new ArgumentException("Element name cannot be null or empty");
            }
            ElementName = elementName;
            Method = method;
        }
        public string ElementName { get; }
        public Action Method { get; }
        
    }

}
