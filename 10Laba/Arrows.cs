using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Laba
{
    internal class Arrows
    {

        public static int max = 4;
        public static int min = 2;
        public static int pozition = 1;
        public static void Arrow(bool needToShowArrow = true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            /*pozition = 0;*/
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pozition--;
                    if (pozition < min)
                    {
                        Console.SetCursorPosition(0, min);
                        Console.Write("   ");
                        pozition = max;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    pozition++;
                    if (pozition > max)
                    {
                        Console.SetCursorPosition(0, max);
                        Console.Write("   ");
                        pozition = min;
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    pozition = -1;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    pozition = -2;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    pozition = -3;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    pozition = -4;
                }
                else if(key.Key == ConsoleKey.Delete)
                {
                    pozition = -5;
                }
                if (pozition >= 1 && needToShowArrow)
                {
                    Console.SetCursorPosition(0, pozition - 1);
                    Console.WriteLine("   ");
                    Console.SetCursorPosition(0, pozition);
                    Console.WriteLine("==>");
                    Console.SetCursorPosition(0, pozition + 1);
                    Console.WriteLine("   ");
                }
                    key = Console.ReadKey();
            }
            /*pozition -= 4;
            Console.Clear();*/
        }
    }
}

