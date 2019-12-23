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
            Queries.InitDB(); // Can be ommitted if neccessary (if we wantt to change the database permanently).
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Queries");
            Console.WriteLine("3. Add entity");
            Console.WriteLine("4. Modify entity");
            Console.WriteLine("5. Remove entity");
            Console.WriteLine("6. Use the JAVA web endpoint");
            Console.WriteLine("7. Exit");
            var input = Console.ReadKey(true).Key;
            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Queries.ListAll();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    QueryMenu();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Operations(Operation.ADD);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Operations(Operation.UPDATE);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Operations(Operation.REMOVE);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
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

        private static void Operations(Operation o)
        {
            Console.Clear();
            Console.WriteLine("1. Country");
            Console.WriteLine("2. Language");
            Console.WriteLine("3. Language family");
            Console.WriteLine("4. Country_lang_link");
            Console.WriteLine("5. Langfam_lang_link");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("7. Exit");
            var input = Console.ReadKey(true).Key;
            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    switch (o)
                    {
                        case Operation.ADD:
                            Queries.AddCountry();
                            break;
                        case Operation.REMOVE:
                            Queries.Remove("country");
                            break;
                        case Operation.UPDATE:
                            Queries.Modify("country");
                            break;
                        default:
                            break;
                    }

                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    switch (o)
                    {
                        case Operation.ADD:
                            Queries.AddLanguage();
                            break;
                        case Operation.REMOVE:
                            Queries.Remove("language");
                            break;
                        case Operation.UPDATE:
                            Queries.Modify("language");
                            break;
                        default:
                            break;
                    }

                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    switch (o)
                    {
                        case Operation.ADD:
                            Queries.AddLanguageFamily();
                            break;
                        case Operation.REMOVE:
                            Queries.Remove("language_family");
                            break;
                        case Operation.UPDATE:
                            Queries.Modify("language_family");
                            break;
                        default:
                            break;
                    }

                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    switch (o)
                    {
                        case Operation.ADD:
                            Queries.AddCountryLangLink();
                            break;
                        case Operation.REMOVE:
                            Queries.Remove("country_lang_link");
                            break;
                        case Operation.UPDATE:
                            Queries.Modify("country_lang_link");
                            break;
                        default:
                            break;
                    }

                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    switch (o)
                    {
                        case Operation.ADD:
                            Queries.AddLangfamLangLink();
                            break;
                        case Operation.REMOVE:
                            Queries.Remove("langfam_lang_link");
                            break;
                        case Operation.UPDATE:
                            Queries.Modify("langfam_lang_link");
                            break;
                        default:
                            break;
                    }

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
        }

        private static void Invalid()
        {
            Console.WriteLine("Invalid key. Press any key to return to the main menu.");
        }
    }
}
