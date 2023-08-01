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

        public string _menuName;
        private int _selectedElement = 0;

        public void AddMenuElement(MenuElement element)
        {
            menuElements.Add(element);
        }

        public void ShowMenu()
        {
            PrintMenu();
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.Enter:
                        menuElements[_selectedElement].Method.Invoke(); break;
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
            }
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            string line = "";
            for (int i = 0; i < FindMaxLenght() + 2; i++)
            {
                line += "-";
            }
            Console.WriteLine(line);
            if (_menuName != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                PrintLine(_menuName);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(line);
            }
            

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
            }
        }

        private void PrintLine(string elmentName)
        {
            int maxLenght = FindMaxLenght();
            Console.Write("|");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write(elmentName);
            Console.ForegroundColor = ConsoleColor.Gray;
            string next = "";
            for (int i = 0; i < maxLenght - elmentName.Length; i++)
            {
                next += " ";
            }
            next += "|";
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
