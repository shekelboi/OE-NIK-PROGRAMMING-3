using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Languages.Logic;

namespace OENIK_PROG3_2019_2_GO10DV
{
    /// <summary>
    /// The main program.
    /// </summary>
    public class Program
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
            Console.WriteLine("6. Exit");
            var input = Console.ReadKey(true).Key;
            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    QueryMenu();
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
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Environment.Exit(0);
                    break;
                default:
                    Invalid();
                    break;
            }

            Console.ReadKey(true);
            Menu();
        }

        private static void QueryMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Rolling up languages and their difficulties");
            Console.WriteLine("2. Language and the language families they belong to");
            Console.WriteLine("3. Official languages by country");
            Console.WriteLine("4. Number of languages by difficulty");
            Console.WriteLine("5. Number of speakers by language");
            Console.WriteLine("6. Main menu");
            Console.WriteLine("7. Exit");

            var input = Console.ReadKey(true).Key;
            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Queries.NumberOfSpeakersRollup();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Queries.LanguageFamilies();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Queries.OfficialLanguages();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Queries.LanguagesByDifficulty();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Queries.NumberOfSpeakers();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    Menu();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    Environment.Exit(0);
                    break;
                default:
                    Invalid();
                    break;
            }

            Console.ReadKey(true);
            Menu();
        }

        private static void Invalid()
        {
            Console.WriteLine("Invalid key. Press any key to return to the main menu.");
        }
    }
}
