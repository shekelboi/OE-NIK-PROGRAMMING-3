namespace Languages.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Languages.Repository;
    using Languages.Data;

    /// <summary>
    /// Accessible query methods for the user.
    /// </summary>
    public class Logic
    {
        /// <summary>
        /// Instance for calling queries.
        /// </summary>
        private static Queries crud = new Queries();

        /// <inheritdoc/>
        public static void InitDB()
        {
            crud.InitDB();
        }

        #region CRUD

        /// <inheritdoc/>
        public static void Remove(string table, string where, string value)
        {
            crud.Remove(table, where, value);
        }

        /// <inheritdoc/>
        public static void Modify(string table, string where, string value, string field, string newValue)
        {
            crud.Modify(table, where, value, field, newValue);
        }

        /// <inheritdoc/>
        public static void AddLangfamLangLink(langfam_lang_link lll)
        {
            crud.AddLangfamLangLink(lll);
        }

        /// <inheritdoc/>
        public static void AddCountryLangLink(country_lang_link cll)
        {
            crud.AddCountryLangLink(cll);
        }

        /// <inheritdoc/>
        public static void AddLanguageFamily(language_family lf)
        {
            crud.AddLanguageFamily(lf);
        }

        /// <inheritdoc/>
        public static void AddLanguage(language l)
        {
            crud.AddLanguage(l);
        }

        /// <inheritdoc/>
        public static void AddCountry(country c)
        {
            Logic.crud.AddCountry(c);
        }

        public static IQueryable GetAll()
        {
            return crud.GetAll();
        }

        #endregion

        #region NONCRUD

        public static string NamesOfCountries()
        {
            var queryable = crud.NamesOfCountries();
            var q = from x in queryable.OfType<country>()
                        select new { A = x.name, B = x.population };

            string result = string.Empty;

            foreach (var item in q)
            {
                result += string.Format("{0, 15} {1, 20}", item.A, item.B);
            }

            return result;
        }

        public static string LanguageFamilies() // STRING CANNOT BE USED
        {
            var db = crud.GetAll();
            var q = from lang in db.OfType<language>()
                    join lll in db.OfType<langfam_lang_link>()
                    on lang.id equals lll.lang_id
                    join langfam in db.OfType<language_family>()
                    on lll.langfam_id equals langfam.id
                    select new { A = lang.name, B = langfam.name };

            string header = string.Format("{0,20} {1,30}", "Language", "Language family");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1,30}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }

        #endregion
    }
}
