﻿// <copyright file="Queries.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Repository
{
    using System.IO;
    using System.Linq;
    using Languages.Data;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// A class for the queries.
    /// </summary>
    public class Queries : IRepository
    {
        /// <summary>
        /// New database entity.
        /// </summary>
        private DatabaseEntities db = new DatabaseEntities();

        public IQueryable GetAll()
        {
            List<object> l = new List<object>();
            l.AddRange(this.db.country.ToList());
            l.AddRange(this.db.country_lang_link.ToList());
            l.AddRange(this.db.langfam_lang_link.ToList());
            l.AddRange(this.db.language.ToList());
            l.AddRange(this.db.language_family.ToList());

            return l.AsQueryable();
        }

        public IQueryable<T> GetAll<T>()
            where T : class
        {
            return db.Set<T>().AsQueryable<T>();
        }

        /// <inheritdoc/>
        public void Remove(string table, string where, string value)
        {
            this.db.Database.ExecuteSqlCommand("delete from " + table + " where " + table + "." + where + " = '" + value + "';");
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Modify(string table, string where, string value, string field, string newValue)
        {
            this.db.Database.ExecuteSqlCommand("update " + table + " set " + field + " = '" + newValue + "' where " + table + "." + where + " = '" + value + "';");
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLangfamLangLink(langfam_lang_link lll)
        {
            this.db.langfam_lang_link.Add(lll);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddCountryLangLink(country_lang_link cll)
        {
            this.db.country_lang_link.Add(cll);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLanguageFamily(language_family lf)
        {
            this.db.language_family.Add(lf);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddLanguage(language l)
        {
            this.db.language.Add(l);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddCountry(country c)
        {
            this.db.country.Add(c);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable NamesOfCountries()
        {
            return this.db.country.AsQueryable();
        }
        /*

        /// <inheritdoc/>
        public string NumberOfSpeakers()
        {
            string sql = "select language.name as [A], sum(country.population) as [B] " +
                "from language " +
                "join langfam_lang_link on language.id = langfam_lang_link.lang_id " +
                "join language_family on language_family.id = langfam_lang_link.langfam_id " +
                "join country_lang_link on language.id = country_lang_link.lang_id " +
                "join country on country.id = country_lang_link.country_id " +
                "group by language.name " +
                "order by sum(country.population) desc;";

            var q = this.db.Database.SqlQuery<Items<string, int>>(sql);

            string header = string.Format("{0,20} {1, 20}", "Language", "Speakers");

            string result = header + "\n";

            foreach (var item in q)
            {
                string s = string.Format("{0,20} {1, 20}", item.A, item.B) + "\n";
                result += s;
            }

            return result;
        }*/
    }
}
