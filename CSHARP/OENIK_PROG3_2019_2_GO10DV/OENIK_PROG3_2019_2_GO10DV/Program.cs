namespace OENIK_PROG3_2019_2_GO10DV
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Languages.Repository;
    using Languages.Data;
    using System.Reflection;


    /// <summary>
    /// The main program.
    /// </summary>
    public class Program
    {
        private static Queries q = new Queries();

        private static void Main(string[] args)
        {
            q.InitDB(); // Can be ommitted if neccessary (if we wantt to change the database permanently).
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
                    Console.WriteLine(q.ListAll());
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
            try
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine(q.NumberOfSpeakersRollup());
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine(q.LanguageFamilies());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine(q.OfficialLanguages());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine(q.LanguagesByDifficulty());
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.WriteLine(q.NumberOfSpeakers());
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            try
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        switch (o)
                        {
                            case Operation.ADD:
                                AddCountryPrompt();
                                break;
                            case Operation.REMOVE:
                                RemovePrompt("country");
                                break;
                            case Operation.UPDATE:
                                ModifyPrompt("country");
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
                                AddLanguagePrompt();
                                break;
                            case Operation.REMOVE:
                                RemovePrompt("language");
                                break;
                            case Operation.UPDATE:
                                ModifyPrompt("language");
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
                                AddLanguageFamilyPrompt();
                                break;
                            case Operation.REMOVE:
                                RemovePrompt("language_family");
                                break;
                            case Operation.UPDATE:
                                ModifyPrompt("language_family");
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
                                AddCountryLangLinkPrompt();
                                break;
                            case Operation.REMOVE:
                                RemovePrompt("country_lang_link");
                                break;
                            case Operation.UPDATE:
                                ModifyPrompt("country_lang_link");
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
                                AddLangfamLangLinkPrompt();
                                break;
                            case Operation.REMOVE:
                                RemovePrompt("langfam_lang_link");
                                break;
                            case Operation.UPDATE:
                                ModifyPrompt("langfam_lang_link");
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddLangfamLangLinkPrompt()
        {
            langfam_lang_link lll = new langfam_lang_link();
            string input;

            // Language family id
            Console.Write("langfam_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int langfam_id))
                {
                    lll.langfam_id = langfam_id;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Language id
            Console.Write("lang_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int lang_id))
                {
                    lll.lang_id = lang_id;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }
        }

        private static void AddCountryLangLinkPrompt()
        {
            country_lang_link cll = new country_lang_link();
            string input;

            // Country id
            Console.Write("lang_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int country_id))
                {
                    cll.country_id = country_id;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Language id
            Console.Write("lang_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int lang_id))
                {
                    cll.lang_id = lang_id;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            q.AddCountryLangLink(cll);
        }

        private static void AddLanguageFamilyPrompt()
        {
            language_family lf = new language_family();
            string input;

            // Name
            Console.Write("Name: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                lf.name = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // ISO code
            Console.Write("ISO code: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                lf.iso_code = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Number of speakers
            Console.Write("Number of speakers: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int speakers))
                {
                    lf.number_of_speakers = speakers;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Rank by number of speakers
            Console.Write("Rank by number of speakers: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int rank_speakers))
                {
                    lf.rank_by_no_speakers = rank_speakers;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Number of languages.
            Console.Write("Number of languages: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int no_languages))
                {
                    lf.number_of_languages = no_languages;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Rank by number of languages
            Console.Write("Rank by number of languages: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int rank))
                {
                    lf.rank_by_no_languages = rank;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            q.AddLanguageFamily(lf);
        }

        private static void AddLanguagePrompt()
        {
            language l = new language();
            string input;

            // Name
            Console.Write("Name: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                l.name = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Agglutinative
            Console.Write("Agglutinative (Y/N): ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                l.agglutinative = input.ToUpper();
            }
            else
            {
                throw new EmptyInputException();
            }

            // Number of tenses
            Console.Write("Number of tenses: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int tenses))
                {
                    l.number_of_tenses = tenses;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Number of noun declension cases
            Console.Write("Number of noun declension cases: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int declension))
                {
                    l.no_of_noun_declension_cases = declension;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Difficulty
            Console.Write("Difficulty: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                l.difficulty = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Number of speakers
            Console.Write("Number of speakers: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int numb_speakers))
                {
                    l.number_of_speakers = numb_speakers;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Rank by number of speakers
            Console.Write("Rank by number of speakers: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int rank_speakers))
                {
                    l.rank_by_no_speakers = rank_speakers;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            q.AddLanguage(l);
        }

        private static void AddCountryPrompt()
        {
            country c = new country();
            string input;

            // Name
            Console.Write("Name: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                c.name = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Population
            Console.Write("Population: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int population))
                {
                    c.population = population;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            // Capital
            Console.Write("Capital: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                c.capital = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Continent
            Console.Write("Continent: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                c.continent = input;
            }
            else
            {
                throw new EmptyInputException();
            }

            // Area
            Console.Write("Area: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                if (int.TryParse(input, out int area))
                {
                    c.area = area;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new EmptyInputException();
            }

            q.AddCountry(c);
        }

        private static void RemovePrompt(string table)
        {
            Console.Write("WHERE: ");
            string where = Console.ReadLine();
            Console.Write("EQUAL TO: ");
            string value = Console.ReadLine();
            q.Remove(table, where, value);
        }

        private static void ModifyPrompt(string table)
        {
            Console.Write("WHERE: ");
            string where = Console.ReadLine();
            Console.Write("EQUAL TO: ");
            string value = Console.ReadLine();
            Console.Write("FIELD TO UPDATE: ");
            string field = Console.ReadLine();
            Console.Write("NEW VALUE: ");
            string newValue = Console.ReadLine();
            q.Modify(table, where, value, field, newValue);
        }

        private static void Invalid()
        {
            Console.WriteLine("Invalid key. Press any key to return to the main menu.");
        }
    }
}
