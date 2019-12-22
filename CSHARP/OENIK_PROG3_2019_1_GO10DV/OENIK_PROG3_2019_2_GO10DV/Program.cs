using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Languages.Logic;

namespace OENIK_PROG3_2019_2_GO10DV
{
    public class Program // Main program
    {
        private static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Queries");
            Console.WriteLine("2. Add entity");
            Console.WriteLine("3. Modify entity");
            Console.WriteLine("4. Remove entity");
            Console.WriteLine("5. Use the JAVA web endpoint");
            var input = Console.ReadKey(true).Key;
            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Queries.NamesOfCountries();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    break;
                //case ConsoleKey.D6:
                //case ConsoleKey.NumPad6:
                //    break;
                default:
                    Console.WriteLine("Invalid key. Press any key to return to the main menu.");
                    break;
            }

            Console.ReadKey(true);
            Menu();
        }
    }
}
