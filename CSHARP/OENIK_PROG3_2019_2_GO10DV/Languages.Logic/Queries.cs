using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Languages.Data;

namespace Languages.Logic
{
    /// <summary>
    /// A class for the queries.
    /// </summary>
    public static class Queries
    {
        private static DatabaseEntities db = new DatabaseEntities();

        /// <summary>
        /// Initializing the database by setting it back to the default state.
        /// </summary>
        public static void InitDB()
        {
            db.Database.ExecuteSqlCommand(File.ReadAllText(@"..\..\..\Languages.Data\SQL\Table creation.sql")); // Because of some caching problem sometimes it doesn't work, if that's the case just modify anything in the source and rebuild the solution.
            db.SaveChanges();
        }

        /// <summary>
        /// Removes a specific entry from the database.
        /// </summary>
        /// <param name="table">Table to remove from.</param>
        public static void Remove(string table)
        {
            Console.Write("WHERE: ");
            string where = Console.ReadLine();
            Console.Write("EQUAL TO: ");
            string value = Console.ReadLine();
            db.Database.ExecuteSqlCommand("delete from " + table + " where " + table + "." + where + " = '" + value + "';");
            db.SaveChanges();
        }

        /// <summary>
        /// Modifying a value inside a table.
        /// </summary>
        /// <param name="table">The table in which we update the value.</param>
        public static void Modify(string table)
        {
            Console.Write("WHERE: ");
            string where = Console.ReadLine();
            Console.Write("EQUAL TO: ");
            string value = Console.ReadLine();
            Console.Write("FIELD TO UPDATE: ");
            string field = Console.ReadLine();
            Console.Write("NEW VALUE: ");
            string newValue = Console.ReadLine();
            db.Database.ExecuteSqlCommand("update " + table + " set " + field + " = '" + newValue + "' where " + table + "." + where + " = '" + value + "';");
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language family-language link.
        /// </summary>
        public static void AddLangfamLangLink()
        {
            langfam_lang_link lll = new langfam_lang_link();
            string input;

            //// ID
            //Console.Write("ID (optional): ");
            //input = Console.ReadLine();

            //if (input != string.Empty)
            //{
            //    if (int.TryParse(input, out int id))
            //    {
            //        cll.id = id;
            //    }
            //    else
            //    {
            //        throw new FormatException();
            //    }
            //}

            // Language family id
            Console.Write("langfam_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                int langfam_id;
                if (int.TryParse(input, out langfam_id))
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
                int lang_id;
                if (int.TryParse(input, out lang_id))
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

            db.langfam_lang_link.Add(lll);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new country-language link.
        /// </summary>
        public static void AddCountryLangLink()
        {
            country_lang_link cll = new country_lang_link();
            string input;

            //// ID
            //Console.Write("ID (optional): ");
            //input = Console.ReadLine();

            //if (input != string.Empty)
            //{
            //    if (int.TryParse(input, out int id))
            //    {
            //        cll.id = id;
            //    }
            //    else
            //    {
            //        throw new FormatException();
            //    }
            //}

            // Country id
            Console.Write("lang_id: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                int country_id;
                if (int.TryParse(input, out country_id))
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
                int lang_id;
                if (int.TryParse(input, out lang_id))
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

            db.country_lang_link.Add(cll);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language family.
        /// </summary>
        public static void AddLanguageFamily()
        {
            language_family lf = new language_family();
            string input;

            //// ID
            //Console.Write("ID (optional): ");
            //input = Console.ReadLine();

            //if (input != string.Empty)
            //{
            //    if (int.TryParse(input, out int id))
            //    {
            //        lf.id = id;
            //    }
            //    else
            //    {
            //        throw new FormatException();
            //    }
            //}

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

            // Agglutinative
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
                int speakers;
                if (int.TryParse(input, out speakers))
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
                int rank_speakers;
                if (int.TryParse(input, out rank_speakers))
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
                int no_languages;
                if (int.TryParse(input, out no_languages))
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
                int rank;
                if (int.TryParse(input, out rank))
                {
                    lf.number_of_languages = rank;
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

            db.language_family.Add(lf);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new language.
        /// </summary>
        public static void AddLanguage()
        {
            language l = new language();
            string input;

            //// ID
            //Console.Write("ID (optional): ");
            //input = Console.ReadLine();

            //if (input != string.Empty)
            //{
            //    if (int.TryParse(input, out int id))
            //    {
            //        l.id = id;
            //    }
            //    else
            //    {
            //        throw new FormatException();
            //    }
            //}

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
                l.agglutinative = input;
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
                int tenses;
                if (int.TryParse(input, out tenses))
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
                int declension;
                if (int.TryParse(input, out declension))
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
                int numb_speakers;
                if (int.TryParse(input, out numb_speakers))
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
                int rank_speakers;
                if (int.TryParse(input, out rank_speakers))
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

            db.language.Add(l);
            db.SaveChanges();
        }

        /// <summary>
        /// Adding a new country.
        /// </summary>
        public static void AddCountry()
        {
            country c = new country();
            string input;

            //// ID
            //Console.Write("ID (optional): ");
            //input = Console.ReadLine();

            //if (input != string.Empty)
            //{
            //    if (int.TryParse(input, out int id))
            //    {
            //        c.id = id;
            //    }
            //    else
            //    {
            //        throw new FormatException();
            //    }
            //}

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

            // Area
            Console.Write("Area: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                int area;
                if (int.TryParse(input, out area))
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

            // Population
            Console.Write("Population: ");
            input = Console.ReadLine();

            if (input != string.Empty)
            {
                int population;
                if (int.TryParse(input, out population))
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

            db.country.Add(c);
            db.SaveChanges();
        }

        /// <summary>
        /// Listing the elements.
        /// </summary>
        public static void NamesOfCountries()
        {
            var q = db.Database.SqlQuery<Items<string, int>>("select name as [A], population as [B] from country;");

            foreach (var item in q)
            {
                Console.WriteLine(item.A);
            }
        }

        /// <summary>
        /// Number of speakers based on the language or the difficulty.
        /// </summary>
        public static void NumberOfSpeakersRollup()
        {
            string sql = "select language.name as [A], language.difficulty as [B], sum(convert(bigint, language.number_of_speakers))" +
                "as [C] from language group by rollup(language.difficulty, language.name);";
            var q = db.Database.SqlQuery<Items<string, string, long>>(sql);

            string header = string.Format("{0,20} {1,10} {2,20}", "Language", "Difficulty", "No. of speakers");

            Console.WriteLine(header + "\n");

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,10} {2,20}", item.A, item.B, item.C);

                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Selecting languages and their corresponding language families.
        /// </summary>
        public static void LanguageFamilies()
        {
            string sql = "select language.name as [A], language_family.name as [B] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id;";
            var q = db.Database.SqlQuery<Items<string, string>>(sql);

            string header = string.Format("{0,20} {1,30}", "Language", "Language family");

            Console.WriteLine(header + "\n");

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,30}", item.A, item.B);

                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Displaying the official languages of each country.
        /// </summary>
        public static void OfficialLanguages()
        {
            string sql = "select concat(country.name, ' has ' + language.name + ' as their official language.') as [A] " +
                "from language join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id";
            var q = db.Database.SqlQuery<Items<string>>(sql);

            string header = string.Format("{0,20}", "Official language");

            Console.WriteLine(header + "\n");

            foreach (var item in q)
            {
                string s = string.Format("{0,20}", item.A);

                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Number of languages by difficulty.
        /// </summary>
        public static void LanguagesByDifficulty()
        {
            string sql = "select language.difficulty as [A], count(language.id) as [B] " +
                "from language group by language.difficulty " +
                "order by [B] desc;";
            var q = db.Database.SqlQuery<Items<string, int>>(sql);


            string header = string.Format("{0,6} {1, 6}", "Difficulty", "No. of speakers");

            Console.WriteLine(header + "\n");

            foreach (var item in q)
            {
                string s = string.Format("{0,6} {1, 6}", item.A, item.B);

                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Displays each of the languages and the number of their speakers in descending order.
        /// </summary>
        public static void NumberOfSpeakers()
        {
            string sql = "select language.name as [A], sum(country.population) as [B] " +
                "from language " +
                "join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id " +
                "group by language.name " +
                "order by sum(country.population) desc;";
            var q = db.Database.SqlQuery<Items<string, int>>(sql);

            string header = string.Format("{0,20} {1, 20}", "Language", "Speakers");

            Console.WriteLine(header + "\n");

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1, 20}", item.A, item.B);

                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Listing all the entries.
        /// </summary>
        public static void ListAll()
        {
            Console.WriteLine("========Countries========");

            Console.WriteLine(string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", "ID", "Name", "Population", "Capital", "Continent", "Area") + "\n");

            foreach (var c in db.country)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 10} {3, 16} {4, 25} {5, 10}", c.id, c.name, c.population, c.capital, c.continent, c.area);

                Console.WriteLine(s);
            }

            Console.WriteLine("========Language families========");

            Console.WriteLine(string.Format("{0, 5} {1, 30} {2, 10} {3, 10} {4, 5} {5, 10} {6, 5}", "ID", "Name", "ISO", "No. of speakers", "Rank by no. of speakers", "No. of languages", "Rank by no. of languages") + "\n");

            foreach (var l in db.language_family)
            {
                string s = string.Format("{0, 5} {1, 30} {2, 10} {3, 10} {4, 5} {5, 10} {6, 5}", l.id, l.name, l.iso_code, l.rank_by_no_speakers, l.rank_by_no_speakers, l.number_of_languages, l.rank_by_no_languages);

                Console.WriteLine(s);
            }

            Console.WriteLine("========Languages========");

            Console.WriteLine(string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 20} {5, 12} {6, 15} {7, 15}", "ID", "Name", "Agglutinative", "No. of tenses", "No. noun decl. cases", "Difficulty", "No. of speakers", "Rank by no. of speakers") + "\n");

            foreach (var l in db.language)
            {
                string s = string.Format("{0, 5} {1, 20} {2, 12} {3, 14} {4, 20} {5, 12} {6, 15} {7, 15}", l.id, l.name, l.agglutinative, l.number_of_tenses, l.no_of_noun_declension_cases, l.difficulty, l.number_of_speakers, l.rank_by_no_speakers);

                Console.WriteLine(s);
            }

            Console.WriteLine("========country_lang_link========");

            Console.WriteLine(string.Format("{0, 5} {1, 15} {2, 15}", "ID", "country_id", "language_id") + "\n");

            foreach (var cl in db.country_lang_link)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", cl.id, cl.country_id, cl.lang_id);

                Console.WriteLine(s);
            }

            Console.WriteLine("========langfam_lang_link========");

            Console.WriteLine(string.Format("{0, 5} {1, 15} {2, 20}", "ID", "language_id", "language_family_id") + "\n");

            foreach (var ll in db.langfam_lang_link)
            {
                string s = string.Format("{0, 5} {1, 15} {2, 15}", ll.id, ll.lang_id, ll.lang_id);

                Console.WriteLine(s);
            }
        }

        private class Items<T1>
        {
            public T1 A { get; set; }
        }

        private class Items<T1, T2>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }
        }

        private class Items<T1, T2, T3>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }

            public T3 C { get; set; }
        }

        private class Items<T1, T2, T3, T4>
        {
            public T1 A { get; set; }

            public T2 B { get; set; }

            public T3 C { get; set; }

            public T4 D { get; set; }
        }
    }
}
