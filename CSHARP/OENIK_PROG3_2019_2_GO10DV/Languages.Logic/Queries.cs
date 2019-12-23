using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// Adding a new language.
        /// </summary>
        public static void AddLanguage()
        {
            //language l = new language();
            //l.agglutinative = "F";
            //l.difficulty = "Hard";
            //l.name = "WHATEVER";
            //l.no_of_noun_declension_cases = 12;
            //l.number_of_speakers = 8298191;
            //l.number_of_tenses = 2;
            //l.rank_by_no_speakers = 10;
            //l.langfam_lang_link.Add(new langfam_lang_link { langfam_id = 2, lang_id = l.id });
            //db.language.Add(l);

            db.Database.SqlQuery<string>("insert into country(name, population, capital, continent, area) values('Bangladesh', 164700000, 'WRONG VALUE', 'Asia', 147570); insert into country_lang_link(country_id, lang_id) values(12, 1)");
        }

        /// <summary>
        /// Adding a new country.
        /// </summary>
        public static void AddCountry()
        {
            country c = new country();
            c.area = 10;
            c.capital = "ok";
            c.continent = "ok";
            c.name = "OKKKK";
            c.population = 829112;
            c.country_lang_link.Add(new country_lang_link { country_id = c.id, lang_id = 2 });
            db.country.Add(c);
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
