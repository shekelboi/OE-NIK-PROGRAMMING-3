// <copyright file="Program.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace OENIK_PROG3_2019_2_GO10DV
{
    using System;
    using System.Net;
    using Languages.Data;
    using Languages.Logic;
    using Languages.Logic.Logics;

    /// <summary>
    /// The main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">Passing arguments while opening the method from console.</param>
        private static void Main(string[] args)
        {
            Logic.InitDb();
            Menu();
        }

        /// <summary>
        /// Main menu.
        /// </summary>
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
                    Console.WriteLine(ListAll());
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
                    JAVA();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    Environment.Exit(0);
                    break;
                default:
                    Invalid();
                    break;
            }

            Logic.DB.SaveChanges();

            Console.ReadKey(true);
            Menu();
        }

        /// <summary>
        /// Query menu.
        /// </summary>
        private static void QueryMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Language and the language families they belong to");
            Console.WriteLine("2. Official languages by country");
            Console.WriteLine("3. Number of languages by difficulty");
            Console.WriteLine("4. Number of speakers by language");
            Console.WriteLine("5. Main menu");
            Console.WriteLine("6. Exit");

            var input = Console.ReadKey(true).Key;
            Console.Clear();
            try
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine(DisplayLanguageFamilies());
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine(DisplayOfficialLanguages());
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine(DisplayLanguagesByDifficulty());
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine(DisplayNumberOfSpeakers());
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Menu();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
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

        /// <summary>
        /// Running different operations on different tables.
        /// </summary>
        /// <param name="o">Type of operation.</param>
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
                                RemoveCountryPrompt();
                                break;
                            case Operation.UPDATE:
                                ModifyCountryPrompt();
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
                                RemoveLanguagePrompt();
                                break;
                            case Operation.UPDATE:
                                ModifyLanguagePrompt();
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
                                RemoveLanguageFamilyPrompt();
                                break;
                            case Operation.UPDATE:
                                ModifyLanguageFamilyPrompt();
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
                                RemoveCountryLangLinkPrompt();
                                break;
                            case Operation.UPDATE:
                                ModifyCountryLangLinkPrompt();
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
                                RemoveLangfamLangLinkPrompt();
                                break;
                            case Operation.UPDATE:
                                ModifyLangfamLangLinkPrompt();
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

        /// <summary>
        /// Displaying the languages and their language families.
        /// </summary>
        /// <returns>Results in a string.</returns>
        private static string DisplayLanguageFamilies()
        {
            string header = string.Format("{0,20} {1,30}", "Language", "Language family");

            string result = header + "\n";

            foreach (var item in new LanguageLogic().LanguageFamilies())
            {
                string s = string.Format("{0,20} {1,30}", item.Language_name, item.Langfam_name) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Displays the number of languages by difficulty.
        /// </summary>
        /// <returns>The results in a string.</returns>
        private static string DisplayLanguagesByDifficulty()
        {
            string header = string.Format("{0,6} {1, 6}", "Difficulty", "No. of speakers");

            string result = header + "\n";

            foreach (var item in new LanguageLogic().LanguagesByDifficulty())
            {
                string s = string.Format("{0,6} {1, 6}", item.Difficulty, item.Sum) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Displays the official languages of each country in a formatted manner.
        /// </summary>
        /// <returns>The results in a string.</returns>
        private static string DisplayOfficialLanguages()
        {
            string header = string.Format("{0,20}", "Official language");

            string result = header + "\n";

            foreach (var item in new LanguageLogic().OfficialLanguages())
            {
                string s = item.Country + " has " + item.Language + " as their official language." + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Displays the number of speakers by difficulty levels.
        /// </summary>
        /// <returns>Returns the result in a string.</returns>
        private static string DisplayNumberOfSpeakers()
        {
            string header = string.Format("{0,10} {1, 20}", "Difficulty", "Speakers");

            string result = header + "\n";

            foreach (var item in new LanguageLogic().NumberOfSpeakers())
            {
                string s = string.Format("{0,10} {1, 20}", item.Difficulty, item.NumberOfSpeakers) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Listing all the entries.
        /// </summary>
        /// <returns>Returns all the data in a string..</returns>
        private static string ListAll()
        {
            string result = string.Empty;
            result += "========Countries========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", "ID", "Name", "Population", "Capital", "Continent", "Area") + "\n\n";

            foreach (var c in new CountryLogic().GetAll())
            {
                string s = string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", c.id, c.name, c.population, c.capital, c.continent, c.area) + "\n";
                result += s;
            }

            result += "========Language families========" + "\n";

            result += string.Format("{0, 5} {1, 30} {2, 10} {3, 20} {4, 25} {5, 20} {6, 25}", "ID", "Name", "ISO", "No. of speakers", "Rank by no. of speakers", "No. of languages", "Rank by no. of languages") + "\n\n";

            foreach (var l in new LanguageFamilyLogic().GetAll())
            {
                string s = string.Format("{0, 5} {1, 30} {2, 10} {3, 20} {4, 25} {5, 20} {6, 25}", l.id, l.name, l.iso_code, l.number_of_speakers, l.rank_by_no_speakers, l.number_of_languages, l.rank_by_no_languages) + "\n";
                result += s;
            }

            result += "========Languages========" + "\n";

            result += string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 25} {5, 20} {6, 20} {7, 25}", "ID", "Name", "Agglutinative", "No. of tenses", "No. noun decl. cases", "Difficulty", "No. of speakers", "Rank by no. of speakers") + "\n\n";

            foreach (var l in new LanguageLogic().GetAll())
            {
                string s = string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 25} {5, 20} {6, 20} {7, 25}", l.id, l.name, l.agglutinative, l.number_of_tenses, l.no_of_noun_declension_cases, l.difficulty, l.number_of_speakers, l.rank_by_no_speakers) + "\n";
                result += s;
            }

            result += "========country_lang_link========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 15}", "ID", "country_id", "language_id") + "\n\n";

            foreach (var cl in new CountryLangLinkLogic().GetAll())
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", cl.id, cl.country_id, cl.lang_id) + "\n";
                result += s;
            }

            result += "========langfam_lang_link========" + "\n";

            result += string.Format("{0, 5} {1, 15} {2, 20}", "ID", "language_id", "language_family_id") + "\n\n";

            foreach (var ll in new LangfamLangLinkLogic().GetAll())
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", ll.id, ll.lang_id, ll.lang_id) + "\n";
                result += s;
            }

            return result;
        }

        /// <summary>
        /// Prompting for a language family-language link table.
        /// </summary>
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

            new LangfamLangLinkLogic().Insert(lll);
        }

        /// <summary>
        /// Prompting for a country table.
        /// </summary>
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

            new CountryLangLinkLogic().Insert(cll);
        }

        /// <summary>
        /// Prompting for a language family table.
        /// </summary>
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

            new LanguageFamilyLogic().Insert(lf);
        }

        /// <summary>
        /// Prompting for a language table.
        /// </summary>
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

            new LanguageLogic().Insert(l);
        }

        /// <summary>
        /// Prompting for a country table.
        /// </summary>
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

            new CountryLogic().Insert(c);
        }

        /// <summary>
        /// Removing a country entry.
        /// </summary>
        private static void RemoveCountryPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Remove(id);
        }

        /// <summary>
        /// Removing a country_lang_link entry.
        /// </summary>
        private static void RemoveCountryLangLinkPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            new CountryLangLinkLogic().Remove(id);
        }

        /// <summary>
        /// Removing a language entry.
        /// </summary>
        private static void RemoveLanguagePrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            new LanguageLogic().Remove(id);
        }

        /// <summary>
        /// Removing a language_family entry.
        /// </summary>
        private static void RemoveLanguageFamilyPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            new LanguageFamilyLogic().Remove(id);
        }

        /// <summary>
        /// Removing a langfam_lang_link entry.
        /// </summary>
        private static void RemoveLangfamLangLinkPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            new LangfamLangLinkLogic().Remove(id);
        }

        /// <summary>
        /// Modifying the country's population.
        /// </summary>
        private static void ModifyCountryPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Population: ");
            int population = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Modify(id, population);
        }

        /// <summary>
        /// Modifying the country lang link's langid.
        /// </summary>
        private static void ModifyCountryLangLinkPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Language id: ");
            int langid = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Modify(id, langid);
        }

        /// <summary>
        /// Modifying the language's number of speakers.
        /// </summary>
        private static void ModifyLanguagePrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of speakers: ");
            int no_speakers = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Modify(id, no_speakers);
        }

        /// <summary>
        /// Modifying the langfam_lang_link's langid.
        /// </summary>
        private static void ModifyLangfamLangLinkPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of speakers: ");
            int langid = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Modify(id, langid);
        }

        /// <summary>
        /// Modifying the language family's number of speakers.
        /// </summary>
        private static void ModifyLanguageFamilyPrompt()
        {
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of speakers: ");
            int no_speakers = Convert.ToInt32(Console.ReadLine());
            new CountryLogic().Modify(id, no_speakers);
        }

        /// <summary>
        /// Java part of the project.
        /// </summary>
        private static void JAVA()
        {
            WebClient wbc = new WebClient();
            string baseURL = "http://localhost:8080/Languages.JavaWeb/LanguageServlet";
            string input = wbc.DownloadString(baseURL + "?" + "population");
            Console.WriteLine("Generating random population for Russia.");
            int population = Convert.ToInt32(input);
            Console.WriteLine();
            new CountryLogic().Modify(1, population);
            Console.WriteLine("Random population added.");
        }

        /// <summary>
        /// Invalid key pressed.
        /// </summary>
        private static void Invalid()
        {
            Console.WriteLine("Invalid key. Press any key to return to the main menu.");
        }
    }
}
