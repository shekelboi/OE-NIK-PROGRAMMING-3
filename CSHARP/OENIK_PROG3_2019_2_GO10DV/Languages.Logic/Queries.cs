using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Languages.Data;

namespace Languages.Logic
{
    public static class Queries
    {
        private static DatabaseEntities db = new DatabaseEntities();

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
